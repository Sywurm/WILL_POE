using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EmployeeMovement : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPathPoints; // Path to follow when spawned
    [SerializeField] private Transform[] firedPathPoints; // Path to follow when fired
    [SerializeField] private Animator animator; // Reference to the Animator component
    [SerializeField] private float sittingRotationY = 90f; // The desired Y-axis rotation when sitting
    [SerializeField] private float sittingHeightAdjustment = 0.0f; // Adjustable height for sitting position
    private NavMeshAgent navMeshAgent;
    private int currentPointIndex = 0;
    private bool isFired = false;
    private bool isSitting = false; // Flag to track if the employee is sitting
    private Transform[] currentPath;

    // Variables for chair movement
    [SerializeField] private Transform[] departmentChairs; // Array to store department chair positions
    private int chairIndex = 0; // Index for the department chairs

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (animator == null)
        {
            animator = GetComponent<Animator>(); // Attempt to find the animator if not assigned
        }
    }

    private void Start()
    {
        // Start moving or handle other behavior
        StartMoving();
    }

    public void StartMoving()
    {
        // Decide which path to follow
        currentPath = isFired ? firedPathPoints : spawnPathPoints;
        currentPointIndex = 0; // Reset index when starting
        MoveToNextPoint();
    }

    private void MoveToNextPoint()
    {
        if (currentPointIndex < currentPath.Length)
        {
            navMeshAgent.SetDestination(currentPath[currentPointIndex].position);
            currentPointIndex++;
            // Set walking animation only when moving
            if (!isSitting)
            {
                animator.SetBool("IsWalking", true);
                animator.SetBool("IsIdle", false);
                animator.SetBool("IsSitting", false);  // Ensure sitting animation is turned off while walking
            }
        }
        else
        {
            // Once the employee reaches the last point of the path
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsIdle", true); // Make sure IsIdle is true when not moving

            if (!isFired)
            {
                HandleSpawnState();
            }
            else
            {
                HandleFiredState();
            }
        }
    }

    // Handle spawn behavior (sitting and rotation)
    private void HandleSpawnState()
    {
        if (!isSitting)
        {
            // Rotate the employee to the sitting position smoothly
            Quaternion targetRotation = Quaternion.Euler(0f, sittingRotationY, 0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 200f); // Smooth rotation

            // Check if the rotation is close to the desired value
            if (Quaternion.Angle(transform.rotation, targetRotation) < 5f)
            {
                // Once rotation is correct, start the sitting process
                animator.SetBool("IsSitting", true);
                animator.SetBool("IsIdle", false);  // Make sure IsIdle is off when sitting
                animator.SetBool("IsWalking", false); // Make sure walking is off when sitting

                isSitting = true; // Set the flag to indicate the employee is sitting
            }
        }
    }

    // Handle fired behavior (firing employee)
    private void HandleFiredState()
    {
        // Fire the employee after reaching the last point on the fired path
        Destroy(gameObject);
    }

    // Public method to seat the employee at a specified chair position
    public void MoveToSeat(int departmentIndex)
    {
        // Move to the chair position corresponding to the department
        chairIndex = departmentIndex; // Set the department index to move the employee to the correct chair
        Vector3 chairPosition = departmentChairs[chairIndex].position;

        // Adjust the Y position for the sitting height
        chairPosition.y += sittingHeightAdjustment; // Adjust the height of the seat as needed
        navMeshAgent.SetDestination(chairPosition);

        // When the employee reaches the chair, start the sitting animation
        StartCoroutine(SitAtChair());
    }

    private IEnumerator SitAtChair()
    {
        while (navMeshAgent.remainingDistance > 0.1f)
        {
            yield return null; // Wait until the employee reaches the chair
        }

        // Once the employee reaches the chair, start sitting
        animator.SetBool("IsSitting", true);
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsWalking", false);
    }

    private void Update()
    {
        // Check if the employee has reached their destination
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f && !isSitting)
        {
            MoveToNextPoint();
        }
        else if (navMeshAgent.remainingDistance >= 0.5f && !isSitting)
        {
            // If the employee is still moving, ensure the walking animation is active
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsSitting", false); // Ensure sitting is off while walking
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            // Move away from the obstacle by using a simple method like pushing the employee slightly
            Vector3 directionAway = transform.position - other.transform.position;
            Vector3 newDestination = transform.position + directionAway.normalized * 2f; // Move 2 units away
            navMeshAgent.SetDestination(newDestination);

            // Optionally, we could wait for a small delay before resuming path to prevent continuous obstacle movement
            StartCoroutine(WaitAndResumePath());
        }
    }

    private IEnumerator WaitAndResumePath()
    {
        yield return new WaitForSeconds(1f); // Wait for 1 second before resuming
        MoveToNextPoint();
    }

    // Public method to fire the employee
    public void FireEmployee()
    {
        isFired = true;
        currentPointIndex = 0;
        StartMoving();
    }
}
