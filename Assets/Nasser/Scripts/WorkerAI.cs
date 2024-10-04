using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class WorkerAI : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints for the worker to move towards
    public float moveSpeed = 3.5f; 
    public float waitTime = 2f; // Time the worker waits at each waypoint
    public float rotationSpeed = 2f; 
    public float stoppingDistance = 1.0f; 
    public float obstacleDetectionRange = 3f; 
    public float obstacleAvoidanceRadius = 2f; 

    public int[] talkingWaypoints; // Indices of waypoints where the worker will trigger a "talking" animation
    public Animator animator; // Reference to the Animator component for controlling animations
    public bool loopBackwards = false; // If true, the AI loops backwards through the waypoints instead of returning to the first waypoint directly

    private NavMeshAgent agent; 
    private int currentWaypointIndex = 0;
    private bool waiting = false; // Tracks if the AI is waiting at a waypoint
    private bool movingBackwards = false; // Tracks if the AI is moving backwards through the waypoints

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // Set initial movement speed and stopping distance for the NavMeshAgent
        agent.speed = moveSpeed;
        agent.stoppingDistance = stoppingDistance;

        // Move the AI to the first waypoint
        GoToNextWaypoint();
    }

    void Update()
    {
        DetectObstacles();

        // Check if the AI has reached its destination and is not already waiting
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !waiting)
        {
            // Start waiting at the current waypoint
            StartCoroutine(WaitAtWaypoint());
        }

        // Manage the AI's walking and idle animations
        if (agent.velocity.magnitude > 0.1f) // AI is moving
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsIdle", false);
        }
        else 
        {
            animator.SetBool("IsWalking", false);

            if (waiting)
            {
                animator.SetBool("IsIdle", true);
            }
        }
    }

    void GoToNextWaypoint()
    {
        if (waypoints.Length == 0) return; 

        // Set the NavMeshAgent's destination to the current waypoint's position
        agent.destination = waypoints[currentWaypointIndex].position;
        if (IsTalkingWaypoint(currentWaypointIndex))
        {
            animator.SetBool("IsTalking", true);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsIdle", false);
        }
        else
        {
            // Disable talking animation if this is not a talking waypoint
            animator.SetBool("IsTalking", false);
        }

        // Logic for moving through waypoints
        if (!loopBackwards) 
        {
            // Move to the next waypoint, or loop back to the first when reaching the last waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
        else // If looping backwards through waypoints
        {
            // Move forwards until reaching the last waypoint, then reverse direction
            if (!movingBackwards)
            {
                currentWaypointIndex++;

                if (currentWaypointIndex >= waypoints.Length) // Reached the last waypoint
                {
                    movingBackwards = true;
                    currentWaypointIndex = waypoints.Length - 2; // Start moving backwards from the second-last waypoint
                }
            }
            else // Moving backwards through the waypoints
            {
                currentWaypointIndex--;

                if (currentWaypointIndex < 0) // Reached the first waypoint
                {
                    movingBackwards = false;
                    currentWaypointIndex = 1; // Start moving forwards again from the second waypoint
                }
            }
        }

        // Play the walking animation when moving to the next waypoint
        animator.SetBool("IsWalking", true);
        animator.SetBool("IsIdle", false);
    }

    // Coroutine to wait at a waypoint for a certain amount of time
    IEnumerator WaitAtWaypoint()
    {
        waiting = true;

        animator.SetBool("IsWalking", false);
        animator.SetBool("IsTalking", false);
        animator.SetBool("IsIdle", true);

        yield return new WaitForSeconds(waitTime);

        waiting = false;
        GoToNextWaypoint(); 
    }

    // Check if the current waypoint is a talking waypoint
    bool IsTalkingWaypoint(int waypointIndex)
    {
        // Iterate through the list of talking waypoints to check if the current index matches
        foreach (int index in talkingWaypoints)
        {
            if (index == waypointIndex)
            {
                return true;
            }
        }
        return false; // Not a talking waypoint
    }

    // Detect obstacles in front of the AI using raycasting
    void DetectObstacles()
    {
        RaycastHit hit; 
        Vector3 forward = transform.TransformDirection(Vector3.forward); 

        if (Physics.Raycast(transform.position, forward, out hit, obstacleDetectionRange))
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                Debug.Log("Obstacle detected: " + hit.collider.name); 

                // Call the function to steer the AI away from the obstacle
                AvoidObstacle();
            }
        }
    }

    // Function to steer the AI around detected obstacles
    void AvoidObstacle()
    {
        Vector3 avoidDirection = Vector3.zero; 
        bool canSteerLeft = false; 
        bool canSteerRight = false;

        // Check if the AI can steer left by casting a ray in the left direction
        Vector3 leftDirection = transform.TransformDirection(Vector3.left);
        if (!Physics.Raycast(transform.position, leftDirection, obstacleDetectionRange))
        {
            canSteerLeft = true; // No obstacle on the left
        }

        // Check if the AI can steer right by casting a ray in the right direction
        Vector3 rightDirection = transform.TransformDirection(Vector3.right);
        if (!Physics.Raycast(transform.position, rightDirection, obstacleDetectionRange))
        {
            canSteerRight = true; // No obstacle on the right
        }

        // Determine which direction to steer based on available paths
        if (canSteerLeft)
        {
            avoidDirection = leftDirection; // Steer left
        }
        else if (canSteerRight)
        {
            avoidDirection = rightDirection; // Steer right
        }

        // If there is an available direction to steer
        if (canSteerLeft || canSteerRight)
        {
            // Adjust the AI's destination to steer around the obstacle
            Vector3 newTarget = transform.position + avoidDirection * obstacleAvoidanceRadius;
            agent.destination = newTarget;
        }
        else
        {

            agent.isStopped = true;
        }
    }

    void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Length == 0)
            return;

        // Draw lines between waypoints
        Gizmos.color = Color.cyan;
        for (int i = 0; i < waypoints.Length; i++)
        {
            if (i > 0)
            {
                Gizmos.DrawLine(waypoints[i - 1].position, waypoints[i].position);
            }
        }

        // Highlight the current waypoint the AI is moving towards
        if (waypoints.Length > 0)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(waypoints[currentWaypointIndex].position, 0.5f); // Draw a sphere at the current target waypoint
        }

        // Draw a line from the AI's starting position to the first waypoint
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, waypoints[0].position);
    }
}
