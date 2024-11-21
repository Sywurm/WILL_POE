using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerAITest : MonoBehaviour
{
    [SerializeField] private EmployeeMovement employeeMovement; // Reference to EmployeeMovement script
    [SerializeField] private GameObject employeePrefab; // Reference to the employee prefab

    private GameObject currentEmployee;

    // Call this method to spawn the employee and make it follow the spawn path
    public void SpawnEmployee()
    {
        if (currentEmployee == null)
        {
            currentEmployee = Instantiate(employeePrefab, Vector3.zero, Quaternion.identity);
            EmployeeMovement employeeMovementScript = currentEmployee.GetComponent<EmployeeMovement>();
            if (employeeMovementScript != null)
            {
                employeeMovementScript.StartMoving();
            }
        }
    }

    // Call this method to fire the employee and make it follow the fired path
    public void FireEmployee()
    {
        if (currentEmployee != null)
        {
            EmployeeMovement employeeMovementScript = currentEmployee.GetComponent<EmployeeMovement>();
            if (employeeMovementScript != null)
            {
                employeeMovementScript.FireEmployee();
            }
        }
    }
}
