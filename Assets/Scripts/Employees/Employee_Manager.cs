using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee_Manager : MonoBehaviour
{
    private List<My_CV> hiredEmployees = new List<My_CV>();
    private GameObject employee;

    //This Region Manages all off the stats of the employees
    #region Getting the Employee Stats
    public void GetEmployees(GameObject employee)
    {
        employee = GameObject.FindWithTag("Employee");
        hiredEmployees.Add(employee.GetComponent<My_CV>());
    }
    #endregion
}
