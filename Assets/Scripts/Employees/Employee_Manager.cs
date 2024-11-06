using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Employee_Manager : MonoBehaviour
{
    public static Employee_Manager instance;
    public TMP_Dropdown department;
    public GameObject employeeCardPrefab;

    #region EmployeeLists
    public List<GameObject> listUnassigned = new List<GameObject>();

    public List<GameObject> listArtist = new List<GameObject>();
    public List<GameObject> listDeveloper = new List<GameObject>();
    public List<GameObject> listUiUX = new List<GameObject>();
    public List<GameObject> listPublicRelations = new List<GameObject>();
    public List<GameObject> listFinance = new List<GameObject>();
    public List<GameObject> listAdvertisement = new List<GameObject>();
    public List<GameObject> listDesigners = new List<GameObject>();
    public List<GameObject> listNarritive = new List<GameObject>();    
    #endregion

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        GetEmployeeStats();
    }

    //This Region Manages all off the stats of the employees
    #region Getting the Employee Stats
    public void SetEmployees(GameObject emp)
    {
        listUnassigned.Add(emp);
    }
    public void GetEmployeeStats()
    {
        switch (department.value)
        {
            case 0:
                for (int j = 0; j < listUnassigned.Count; j++)
                {
                    
                }
                break;
            case 1:
                for (int j = 0; j < listArtist.Count; j++) 
                {
                    //return listArtist[j].gameObject;
                }
                break;
            case 2:
                for (int j = 0; j < listDeveloper.Count; j++) 
                {
                    //return listDeveloper[j].gameObject;
                }
                break;
            case 3:
                for (int j = 0; j < listUiUX.Count; j++) 
                {
                    //return listUiUX[j].gameObject;
                }
                break;
            case 4:
                for (int j = 0; j < listPublicRelations.Count; j++) 
                {
                    //return listPublicRelations[j].gameObject;
                }
                break;
            case 5:
                for (int j = 0; j < listFinance.Count; j++) 
                {
                    //return listFinance[j].gameObject;
                }
                break;
            case 6:
                for (int j = 0; j < listAdvertisement.Count; j++) 
                {
                    //return listAdvertisement[j].gameObject;
                }
                break;
            case 7:
                for (int j = 0; j < listDesigners.Count; j++)
                {
                    //return listDesigners[j].gameObject;
                }
                break;
            case 8:
                for (int j = 0; j < listNarritive.Count; j++)
                {
                    //return listNarritive[j].gameObject;
                }
                break;            
        }
    }
    public void MoveEmployee(GameObject empMove, int newPos)
    {
        //GetEmployeeStats(empMove.gameObject);
    }
    #endregion

    public void GetDropdownValue()
    {
        Debug.Log( department.value);
    }
}
