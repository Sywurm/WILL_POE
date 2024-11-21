using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairManager : MonoBehaviour
{
    [SerializeField]List<GameObject> chairs = new List<GameObject>();

    //Assigns chair to employee
    public void AssignChair(My_CV employee)
    {
        if (employee.e_position != Employee.EmployeePosition.Unassigned)
        {
            for (int i = 0; i < chairs.Count; i++)
            {
                Chair currentChair = chairs[i].gameObject.GetComponent<Chair>();


                if (!currentChair.hasEmployee && currentChair.department == employee.e_position)
                {
                    employee.gameObject.SetActive(false);
                    employee.currentChair = currentChair;
                    currentChair.SetEmployee(employee.sittingModelPos);
                    break;
                }
            }
        }
        else
        {
            employee.currentChair = null;
            employee.gameObject.SetActive(true);
        }
    }
}
