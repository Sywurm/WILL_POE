using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Employee_Manager : MonoBehaviour
{
    public static Employee_Manager instance;
    public TMP_Dropdown department;
    public GameObject employee;
    public CV_Manager cvManager;
    [SerializeField] Button hireButton;
    [SerializeField] GameObject CVpage;
    [SerializeField] GameObject notification;
    private int totalHappiness;
    private int totalEfficientcy;

    // Chair references
    public List<GameObject> chairs; // List to hold chair references
    private List<bool> chairOccupiedStatus; // List to track chair occupancy status

    #region EmployeeLists
    public List<GameObject> listAssigned = new List<GameObject>();
    public List<GameObject> listUnEmployees = new List<GameObject>();
    #endregion

    private void Awake()
    {
        instance = this;
        chairOccupiedStatus = new List<bool>(); // Initialize the chair status list
        foreach (var chair in chairs)
        {
            chairOccupiedStatus.Add(false); // Initially, all chairs are unoccupied
        }
    }

    private void Start()
    {
        SetOfficeStats();
    }

    private void FixedUpdate()
    {
        if (isDone && listAssigned.Count > 0)
        {
            isDone = false;
            CheckUnassignedSpace();
        }

        if (listUnEmployees.Count > 0)
        {
            CVpage.SetActive(true);
        }
        else
        {
            CVpage.SetActive(false);
        }
    }

    // This Region Manages all of the stats of the employees
    #region Getting the Employee Stats
    //Setting the data of the spawned employee
    public void SetEmployees(GameObject emp)
    {
        listUnEmployees.Add(emp);
        CVNotification();
        PlayNotificationSound();
    }

    public void GetEmployeeStats()
    {
        cvManager.ResetEmployee();
    }
    
    // Hireing the employee first in the list
    // Calculating the average of the office hapiness and efficientcy
    public void HireEmployee()
    {
        if (listUnEmployees.Count > 0)
        {
            // Get the employee prefab from the unassigned list
            GameObject employeePrefab = listUnEmployees[0];

            // Add the new employee to the assigned list
            listAssigned.Add(employeePrefab);

            // Disable the employee from the unassigned list
            listUnEmployees.RemoveAt(0);

            // Update stats
            SetOfficeStats();

            CVNotification();
            cvManager.ResetEmployee();
            GetEmployeeStats();



        }
        else
        {
            Debug.Log("No more employees available to hire.");
        }
    }

    //Sets the stats of the office
    int highestEmployeeCount = 0;
    public void SetOfficeStats()
    {
        totalHappiness = 0;
        totalEfficientcy = 0;
        int currentEmployeeCount = listAssigned.Count;

        if(currentEmployeeCount > highestEmployeeCount)
        {
            highestEmployeeCount = currentEmployeeCount;
        }

        if (listAssigned.Count == 0)
        {
            GameManager.instance._OfficeHappiness = totalHappiness;
            GameManager.instance._OfficeEfficiency = totalEfficientcy;
            GameManager.instance.UpdateOfficeStats();
        }
        else
        {
            for (int i = 0; i < listAssigned.Count; i++)
            {
                totalHappiness += (int)listAssigned[i].gameObject.GetComponent<My_CV>().e_Happiness;
                totalEfficientcy += (int)listAssigned[i].gameObject.GetComponent<My_CV>().e_Efficientcy;
                Debug.Log("Total Happiness: " + totalHappiness);
            }
            GameManager.instance._OfficeHappiness = (totalHappiness / (highestEmployeeCount * 100f)) * 100f;
            GameManager.instance._OfficeEfficiency = (totalEfficientcy / (highestEmployeeCount * 100f)) * 100f;
            GameManager.instance.UpdateOfficeStats();
        }
       
    }

    //Removing the employee in the list
    public void DeclineEmployee()
    {
        if (listUnEmployees[0] != null)
        {
            listUnEmployees.RemoveAt(0);
            CVNotification();
            cvManager.ResetEmployee();
            GetEmployeeStats();
        }
        else
        {
            Debug.Log("No more employees");
        }
    }

    // Removing the selected employee and recalculating average
    public void FireEmployee(GameObject emp)
    {
        for (int i = 0; i < listAssigned.Count; i++)
        {
            if (listAssigned[i] == emp)
            {
                listAssigned.RemoveAt(i);

                // Free the chair and disable the employee object
                FreeChair(emp);
                Destroy(emp);
            }
        }

       SetOfficeStats();
    }

    // Free the chair when an employee is fired
    private void FreeChair(GameObject emp)
    {
        for (int i = 0; i < chairs.Count; i++)
        {
            if (emp.transform.position == chairs[i].transform.position)
            {
                // Disable the employee object parented to the chair
                Transform chairChild = chairs[i].transform.GetChild(0); // Assuming the employee is the first child of the chair
                chairChild.gameObject.SetActive(false); // Disable the employee object

                chairOccupiedStatus[i] = false; // Mark the chair as unoccupied
                break;
            }
        }
    }

    #endregion

    bool isDone = true;
    int unassignedCount = 0;

    public void GetDropdownValue()
    {
        Debug.Log(department.value);
    }

    public void CheckUnassignedSpace()
    {
        if (listAssigned.Count > 0)
        {
            for (int i = 0; i < listAssigned.Count; i++)
            {
                My_CV selectedEmployee = listAssigned[i].gameObject.GetComponent<My_CV>();
                if (selectedEmployee.e_position == Employee.EmployeePosition.Unassigned)
                {
                    unassignedCount++;
                }

                if (unassignedCount >= 4)
                {
                    hireButton.interactable = false;
                    break;
                }
                else
                {
                    hireButton.interactable = true;
                }
            }
            unassignedCount = 0;
            isDone = true;
        }
    }

    private void CVNotification()
    {
        if (listUnEmployees.Count > 0)
        {
            notification.SetActive(true);
        }
        else
        {
            notification.SetActive(false);
        }
    }

    private void PlayNotificationSound()
    {
        FindAnyObjectByType<ButtonManager>().PlayNotificationSound();
    }
}
