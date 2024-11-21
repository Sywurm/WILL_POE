using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    [SerializeField] List<GameObject> sittingEmployee = new List<GameObject>();
    public Employee.EmployeePosition department = Employee.EmployeePosition.Unassigned;
    public bool hasEmployee = false;

    public void SetEmployee(int position)
    {
        sittingEmployee[position].SetActive(true);
        hasEmployee = true;
    }

    public void ResetChair()
    {
        foreach(GameObject model in sittingEmployee) 
        {
            model.SetActive(false);
            hasEmployee = false;
        }
    }
}
