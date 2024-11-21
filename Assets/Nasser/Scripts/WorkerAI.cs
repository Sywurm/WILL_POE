using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class WorkerAI : MonoBehaviour
{
    public List<Transform> pathObjects; // List of parent objects containing different sets of waypoints
    public List<Transform> spawnPoints; // Separate spawn points for workers
    public List<Transform> exitPoints; // Separate exit points for workers

    public int currentPathIndex = 0;
    public float moveSpeed = 3.5f;
    public float waitTime = 2f;
    public float stoppingDistance = 1.0f;

    public Animator animator;

    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;
    private bool waiting = false;
    private Transform[] waypoints;

    // Workstation management
    public Transform[] workstations; // Array of workstations
    private bool goingToWorkstation = false; // Whether AI is directed to a workstation
    private Transform targetWorkstation; // Current workstation target

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
        agent.stoppingDistance = stoppingDistance;
    }

    void Update()
    {
        UpdateAnimator();
    }

    void UpdateAnimator()
    {
        if (agent.velocity.magnitude > 0.1f)
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsSitting", false);
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

    public void SpawnWorker(int spawnPointIndex, int pathIndex)
    {
        if (spawnPointIndex < 0 || spawnPointIndex >= spawnPoints.Count || pathIndex < 0 || pathIndex >= pathObjects.Count)
        {
            Debug.LogError("Invalid spawn point or path index!");
            return;
        }

        transform.position = spawnPoints[spawnPointIndex].position; // Set spawn position
        currentPathIndex = pathIndex;
        LoadPath(currentPathIndex); // Load the assigned path
    }

    public void FireWorker(int exitPointIndex)
    {
        if (exitPointIndex < 0 || exitPointIndex >= exitPoints.Count)
        {
            Debug.LogError("Invalid exit point index!");
            return;
        }

        Transform exitPoint = exitPoints[exitPointIndex];
        agent.destination = exitPoint.position; // Move to the exit
        StartCoroutine(ExitGame(exitPoint));
    }

    public void LoadPath(int pathIndex)
    {
        if (pathIndex < 0 || pathIndex >= pathObjects.Count)
        {
            Debug.LogError("Invalid path index!");
            return;
        }

        currentPathIndex = pathIndex;
        currentWaypointIndex = 0;

        waypoints = pathObjects[currentPathIndex].GetComponentsInChildren<Transform>();
        waypoints = System.Array.FindAll(waypoints, t => t != pathObjects[currentPathIndex]);

        GoToNextWaypoint();
    }

    void GoToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        agent.destination = waypoints[currentWaypointIndex].position;

        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
        {
            StartCoroutine(SitAtEnd());
        }
    }

    IEnumerator SitAtEnd()
    {
        while (agent.remainingDistance > stoppingDistance)
        {
            yield return null; // Wait until the AI reaches the end
        }

        agent.isStopped = true;
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsSitting", true); // Play sitting animation
    }

    IEnumerator WaitAtWaypoint()
    {
        waiting = true;
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsIdle", true);
        yield return new WaitForSeconds(waitTime);
        waiting = false;
        GoToNextWaypoint();
    }

    IEnumerator ExitGame(Transform exitPoint)
    {
        while (Vector3.Distance(transform.position, exitPoint.position) > stoppingDistance)
        {
            yield return null; // Wait until the AI reaches the exit
        }

        agent.isStopped = true;
        Destroy(gameObject); // Remove the worker from the game
    }

    // Gizmos method to visualize the path
    void OnDrawGizmos()
    {
        // Draw path if waypoints are available
        if (waypoints != null && waypoints.Length > 0)
        {
            Gizmos.color = Color.red; // Set the color of the gizmo line
            for (int i = 0; i < waypoints.Length - 1; i++)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position); // Draw a line between waypoints
            }
        }
    }
}
