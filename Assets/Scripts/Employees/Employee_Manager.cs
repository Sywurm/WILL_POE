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
    public CV_Manager cvManager;

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
        cvManager.ResetEmployee();
        //employee = listUnEmployees[0];
        //if (employee != null && !employee.GetComponent<My_CV>().e_IsHired)
        //{
        //    //Display the employee on the Ui
        //}
    }

    public void HireEmployee()
    {
        if (listUnEmployees[0] != null)
        {
            listUnEmployees[0].gameObject.GetComponent<My_CV>().e_IsHired = true;
            //Generate the employee card

            listUnassigned.Add(listUnEmployees[0]);
            listUnEmployees.Remove(listUnEmployees[0]);
            cvManager.ResetEmployee();
            GetEmployeeStats();
        }
        else
        {
            Debug.Log("No more employees");
        }
    }

    //Thanos snap code
    public void DeclineEmployee()
    {
        if (listUnEmployees[0] != null)
        {
            listUnEmployees.RemoveAt(0);
            cvManager.ResetEmployee();
            GetEmployeeStats();
        }
        else
        {
            Debug.Log("No more employees");
        }
    }

    public void FireEmployee(GameObject emp)
    {
        for (int i = 0; i < listUnassigned.Count; i++)
        {
            if(listUnassigned[i] == emp)
            {
                listUnassigned.RemoveAt(i);
                Destroy(emp);
            }
        }
        for (int i = 0; i < listAssigned.Count; i++)
        {
            if(listAssigned[i] == emp)
            {
                listAssigned.RemoveAt(i);
                Destroy(emp);
            }
        }
        
    }

    public void MoveEmployee(GameObject empMove, Employee.EmployeePosition pos)
    {
        for (int i = 0; i < listUnassigned.Count; i++)
        {
            if(listUnassigned[i] == empMove && listUnassigned[i].gameObject.GetComponent<My_CV>().e_position != pos)
            {
                listUnassigned[i].gameObject.GetComponent<My_CV>().e_position = pos;
                listAssigned.Add(listUnassigned[i]);
                listUnassigned.RemoveAt(i);
            }
        }
    }
    #endregion

    public void GetDropdownValue()
    {
        Debug.Log( department.value);
    }
}
