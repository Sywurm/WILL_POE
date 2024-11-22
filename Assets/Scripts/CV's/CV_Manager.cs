using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CV_Manager : MonoBehaviour
{
    [Header("CV Settings")]
    [SerializeField] private GameObject empName;
    [SerializeField] private GameObject empPicture;

    [SerializeField] private Slider empHappiness;
    [SerializeField] private Slider empEfficiency;
    [SerializeField] private Slider empProductivity;

    [SerializeField] private Image empHappinessFill;
    [SerializeField] private Image empEfficiencyFill;
    [SerializeField] private Image empProductivityFill;

    [SerializeField] private GameObject empSkill;
    [SerializeField] private GameObject empBiography;
    [SerializeField] private GameObject empEducation;
    [SerializeField] private GameObject empWorkExperience;

    // Setting up the CV Ui with the values from the employee
    public void SetCV(GameObject employee)
    {
        empName.GetComponent<TMP_Text>().text = employee.GetComponent<My_CV>().e_Name;
        empPicture.GetComponent<Image>().sprite = employee.GetComponent<My_CV>().e_EmployeeFoto;

        float happieness = employee.GetComponent<My_CV>().e_Happiness;
        float productivity = employee.GetComponent<My_CV>().e_Productivity;
        float effeciency = employee.GetComponent<My_CV>().e_Efficientcy;

        empHappiness.value = happieness;
        empEfficiency.value = effeciency;
        empProductivity.value = productivity;

        switch (happieness)
        {
            case float i when i >= 0f && i < 33f:
                {
                    empHappinessFill.color = GameManager.instance.low;
                    break;
                }
            case float i when i >= 33f && i < 66f:
                {
                    empHappinessFill.color = GameManager.instance.mid;
                    break;
                }
            case float i when i >= 66f && i < 100f:
                {
                    empHappinessFill.color = GameManager.instance.high;
                    break;
                }
        }

        switch (productivity)
        {
            case float i when i >= 0f && i < 33f:
                {
                    empProductivityFill.color = GameManager.instance.low;
                    break;
                }
            case float i when i >= 33f && i < 66f:
                {
                    empProductivityFill.color = GameManager.instance.mid;
                    break;
                }
            case float i when i >= 66f && i < 100f:
                {
                    empProductivityFill.color = GameManager.instance.high;
                    break;
                }
        }

        switch (effeciency)
        {
            case float i when i >= 0f && i < 33f:
                {
                    empEfficiencyFill.color = GameManager.instance.low;
                    break;
                }
            case float i when i >= 33f && i < 66f:
                {
                    empEfficiencyFill.color = GameManager.instance.mid;
                    break;
                }
            case float i when i >= 66f && i < 100f:
                {
                    empEfficiencyFill.color = GameManager.instance.high;
                    break;
                }
        }

        //Change interactability for the productivity slider
        empBiography.GetComponent<TMP_Text>().text = employee.GetComponent<My_CV>().e_bio;
        
        for(int i = 0; i < employee.GetComponent<My_CV>().e_skills.Count; i++)
        {
            empSkill.GetComponent<TMP_Text>().text += i + 1 + " - " + employee.GetComponent<My_CV>().e_skills[i] + "\n";
        }        

        for(int i = 0; i < employee.GetComponent<My_CV>().e_edu.Count; i++)
        {
            empEducation.GetComponent<TMP_Text>().text += employee.GetComponent<My_CV>().e_edu[i] + "\n";
        }

        for (int i = 0; i< employee.GetComponent<My_CV>().e_workExp.Count; i++)
        {
            empWorkExperience.GetComponent<TMP_Text>().text += employee.GetComponent<My_CV>().e_workExp[i] + "\n";
        }
    }

    // Reseting the CV Ui so it can take new values
    public void ResetEmployee()
    {
        empName.GetComponent<TMP_Text>().text = "";
        empPicture.GetComponent<Image>().sprite = null;
        empHappiness.value = 0;
        empEfficiency.value = 0;
        empProductivity.value = 0;
        empBiography.GetComponent<TMP_Text>().text = "";
        empSkill.GetComponent<TMP_Text>().text = "";
        empEducation.GetComponent<TMP_Text>().text = "";
        empWorkExperience.GetComponent<TMP_Text>().text = "";

        if(Employee_Manager.instance.listUnEmployees.Count > 0)
        {
            SetCV(Employee_Manager.instance.listUnEmployees[0]);
        }
        
    }
}
