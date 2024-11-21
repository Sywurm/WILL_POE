using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class EmployeeCardManager : MonoBehaviour
{
    [SerializeField] List<GameObject> employeeStatCards = new List<GameObject>();

    [SerializeField] List<My_CV> departmentEmployees = new List<My_CV>();
    [SerializeField] TMP_Dropdown departmentSelection;

    [SerializeField] Employee_Manager employeeManager;

    [SerializeField] List<Employee.EmployeePosition> departmentTypes;
    [SerializeField]List<Employee.EmployeePosition> availableDepartmentTypes = new List<Employee.EmployeePosition>();

    [SerializeField] List<TMP_Dropdown> transferDropdowns = new List<TMP_Dropdown>();
    private void Start()
    {
        departmentTypes.AddRange(Enum.GetValues(typeof(Employee.EmployeePosition)));
        availableDepartmentTypes.AddRange(departmentTypes);
        GetEmployees();
    }

    //Gets current employees in selected department
    public void GetEmployees()
    {
        int selectedIndex = departmentSelection.value;
        Debug.Log("Employee selection:" + selectedIndex);
        Employee.EmployeePosition selectedPosition = (Employee.EmployeePosition)selectedIndex;

        departmentEmployees.Clear();

        if(employeeManager.listAssigned.Count != 0)
        {
            for (int i = 0; i < employeeManager.listAssigned.Count; i++)
            {
                My_CV selectedEmployee = employeeManager.listAssigned[i].GetComponent<My_CV>();
                if (selectedEmployee.e_position == selectedPosition)
                {
                    departmentEmployees.Add(selectedEmployee);
                }
            }

            DisplayEmployees();
        }
        else
        {
            ResetCards();
        }
        
    }

    private void DisplayEmployees()
    {
        ResetCards();
        ValidateEmployeeMoves();

        for (int i = 0; i < departmentEmployees.Count; i++) 
        {
            employeeStatCards[i].SetActive(true);
            Image employeeIcon = employeeStatCards[i].transform.GetChild(0).GetComponent<Image>();
            TMP_Text nameText = employeeStatCards[i].transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>();
            Slider efficiency = employeeStatCards[i].transform.GetChild(1).transform.GetChild(0).GetComponent<Slider>();
            Slider attituded = employeeStatCards[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Slider>();
            Slider productivity = employeeStatCards[i].transform.GetChild(3).transform.GetChild(0).GetComponent<Slider>();
            TMP_Dropdown reassignDropdown = employeeStatCards[i].transform.GetChild(5).GetComponent<TMP_Dropdown>();
            
            employeeIcon.sprite = departmentEmployees[i].e_EmployeeFoto;
            nameText.text = departmentEmployees[i].e_Name;
            efficiency.value = departmentEmployees[i].e_Efficientcy / 100f;
            attituded.value = departmentEmployees[i].e_Happiness / 100f;
            productivity.value = departmentEmployees[i].e_Productivity / 100f;
            //reassignDropdown.value = (int)departmentEmployees[i].e_position;

            //string employeedepartmentenum = departmentEmployees[i].e_position.ToString();
            //string modifiedEnum = Regex.Replace(employeedepartmentenum, "(?<!^)([A-Z])", " $1");
            //Debug.Log("Modified enum: " + modifiedEnum);
            for (int j = 0; j < reassignDropdown.options.Count; j++)
            {
                if (reassignDropdown.options[j].text.ToString().Replace(" ", "") == departmentEmployees[i].e_position.ToString())
                {
                    reassignDropdown.value = j;
                    reassignDropdown.RefreshShownValue();
                    break;
                }

            }


        }

        
    }

    private void ResetCards()
    {
        for (int i = 0; i < employeeStatCards.Count; i++)
        {
            employeeStatCards[i].SetActive(false);
        }
    }

    #region Department movement and validation

    //Gets the eployee to move from card and moves them
    public void MoveEmployee(TMP_Dropdown _trigger)
    {
        GameObject employeeCardRef = _trigger.gameObject.transform.parent.gameObject;
        int cardIndex = 0;

        //Finds dropdown connected card
        for(int i = 0; i < employeeStatCards.Count; i++)
        {
            if(employeeCardRef == employeeStatCards[i].gameObject) 
            {
                cardIndex = i; 
                break;
            }
        }

        string selectedDepartment = _trigger.options[_trigger.value].text.ToString().Replace(" ", "");
        int selectedDepartmentIndex = 0;
        Debug.Log("Selected department:" + selectedDepartment);

        for (int i = 0; i < departmentTypes.Count; i++)
        {
           
            if(selectedDepartment == departmentTypes[i].ToString())
            {
                selectedDepartmentIndex = i;

                Debug.Log("Selected department index: " +selectedDepartmentIndex);
                break;
            }
        }

        departmentEmployees[cardIndex].e_position = (Employee.EmployeePosition)selectedDepartmentIndex;
        GetEmployees();
    }

    private void ValidateEmployeeMoves()
    {
        availableDepartmentTypes.Clear();
        availableDepartmentTypes.AddRange(departmentTypes);

        int currentdepartmentSelection = departmentSelection.value;
        //Loop through all assigned employees
        if(employeeManager.listAssigned.Count != 0)
        {
            for (int i = 0; i < departmentTypes.Count; i++)
            {
                int count = 0;

                if(i != currentdepartmentSelection)
                {
                    for (int j = 0; j < employeeManager.listAssigned.Count; j++)
                    {
                        My_CV selectedEmployee = employeeManager.listAssigned[j].GetComponent<My_CV>();

                        if (selectedEmployee.e_position == departmentTypes[i])
                        {
                            count++;
                        }

                        if (count >= 4)
                        {
                            break;
                        }
                    }

                    if (count >= 4)
                    {
                        availableDepartmentTypes.RemoveAt(i);
                    }
                }
                
            }
        }
        
        UpdateOptions();
    }

    private void UpdateOptions()
    {
        List<string> stringOptions = new List<string>();

        for (int i = 0; i < availableDepartmentTypes.Count; i++)
        {
            string selectedOption = availableDepartmentTypes[i].ToString();
            string manipulatedOption = Regex.Replace(selectedOption, "(?<!^)([A-Z])", " $1");
            stringOptions.Add(manipulatedOption);
        }

        for (int i = 0; i < transferDropdowns.Count; i++)
        {
            TMP_Dropdown selectedDropdown = transferDropdowns[i];
            
            selectedDropdown.options.Clear();

            for (int j = 0; j < stringOptions.Count; j++)
            {
                TMP_Dropdown.OptionData selectedOption = new TMP_Dropdown.OptionData(stringOptions[j].ToString());
                selectedDropdown.options.Add(selectedOption);
            }

            selectedDropdown.RefreshShownValue();
        }
    }

    #endregion

    public void FireEmployee(Button _firebutton)
    {
        GameObject attatchedCard = _firebutton.gameObject.transform.parent.gameObject;
        int cardIndex = 0;
        for (int i = 0; i < employeeStatCards.Count; i++)
        {
            if (employeeStatCards[i] == attatchedCard)
            {
                cardIndex = i;
                break;
            }
        }

        Employee_Manager.instance.FireEmployee(departmentEmployees[cardIndex].gameObject);
        GetEmployees();
    }

}
