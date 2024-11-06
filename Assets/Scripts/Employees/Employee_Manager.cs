using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Employee_Manager : MonoBehaviour
{
    public static Employee_Manager instance;
    public TMP_Dropdown department;
    public GameObject employee;

    #region EmployeeLists
    public List<GameObject> listUnassigned = new List<GameObject>();
    public List<GameObject> listAssigned = new List<GameObject>();
    public List<GameObject> listUnEmployees = new List<GameObject>();
    #endregion

    private void Awake()
    {
        instance = this;
    }

    //This Region Manages all off the stats of the employees
    #region Getting the Employee Stats
    public void SetEmployees(GameObject emp)
    {
        listUnEmployees.Add(emp);
        //GetEmployeeStats();
    }
    public void GetEmployeeStats()
    {
        employee = listUnEmployees[0];
        if (employee != null && !employee.GetComponent<My_CV>().e_IsHired)
        {
            //Display the employee on the Ui
        }
    }

    public void HireEmployee()
    {
        listUnEmployees[0].gameObject.GetComponent<My_CV>().e_IsHired = true;
        listUnassigned.Add(listUnEmployees[0]);
        listUnEmployees.Remove(listUnEmployees[0]);
        GetEmployeeStats();
    }

    //Thanos snap code
    public void DeclineEmployee()
    {
        Destroy(listUnEmployees[0]);
        GetEmployeeStats();
    }

    public void MoveEmployee(GameObject empMove)
    {
        
    }
    #endregion

    public void GetDropdownValue()
    {
        Debug.Log( department.value);
    }
}
