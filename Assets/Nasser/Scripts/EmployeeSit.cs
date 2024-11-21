using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EmployeeSit : MonoBehaviour
{
   
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


    private void Start()
    {
        animator.SetBool("IsSitting", true);
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsWalking", false);
    }
 


}
