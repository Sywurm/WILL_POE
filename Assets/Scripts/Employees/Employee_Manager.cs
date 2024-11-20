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
    [SerializeField] Button hireButton;
    [SerializeField] GameObject CVpage;

    #region EmployeeLists
    //public List<GameObject> listUnassigned = new List<GameObject>();
    public List<GameObject> listAssigned = new List<GameObject>();
    public List<GameObject> listUnEmployees = new List<GameObject>();
    #endregion

    private void Awake()
    {
        instance = this;
    }
    private void FixedUpdate()
    {
        if(isDone && listAssigned.Count > 0)
        {
            isDone = false;
            CheckUnassignedSpace();
        }

        if(listUnEmployees.Count > 0) 
        {
            CVpage.SetActive(true);
        }
        else
        {
            CVpage.SetActive(false);
        }
      
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
        if (listUnEmployees.Count != 0)
        {
            listUnEmployees[0].gameObject.GetComponent<My_CV>().e_IsHired = true;
            //Generate the employee card
            listAssigned.Add(listUnEmployees[0]);
            GameManager.instance._OfficeHappiness += listUnEmployees[0].GetComponent<My_CV>().e_Happiness;
            GameManager.instance._OfficeEfficiency += listUnEmployees[0].GetComponent<My_CV>().e_Efficientcy;
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
        //for (int i = 0; i < listUnassigned.Count; i++)
        //{
        //    if(listUnassigned[i] == emp)
        //    {
        //        listUnassigned.RemoveAt(i);
        //        Destroy(emp);
        //    }
        //}
        for (int i = 0; i < listAssigned.Count; i++)
        {
            if(listAssigned[i] == emp)
            {
                GameManager.instance._OfficeHappiness -= emp.GetComponent<My_CV>().e_Happiness;
                GameManager.instance._OfficeEfficiency -= emp.GetComponent<My_CV>().e_Efficientcy;
                listAssigned.RemoveAt(i);
                Destroy(emp);
            }
        }
        
    }

    //public void MoveEmployee(GameObject empMove, Employee.EmployeePosition pos)
    //{
    //    for (int i = 0; i < listUnassigned.Count; i++)
    //    {
    //        if(listUnassigned[i] == empMove && listUnassigned[i].gameObject.GetComponent<My_CV>().e_position != pos)
    //        {
    //            listUnassigned[i].gameObject.GetComponent<My_CV>().e_position = pos;
    //            listAssigned.Add(listUnassigned[i]);
    //            listUnassigned.RemoveAt(i);
    //        }
    //    }
    //}
    #endregion

    bool isDone = true;
    int unassignedCount = 0;

    public void GetDropdownValue()
    {
        Debug.Log( department.value);
    }
    
    public void CheckUnassignedSpace()
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
