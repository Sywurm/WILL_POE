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
    [SerializeField] private GameObject empHappiness;
    [SerializeField] private GameObject empEfficiency;
    [SerializeField] private GameObject empProductivity;
    [SerializeField] private GameObject empSkill;
    [SerializeField] private GameObject empBiography;
    [SerializeField] private GameObject empEducation;
    [SerializeField] private GameObject empWorkExperience;

    public void SetCV(GameObject employee)
    {
        empName.GetComponent<Text>().text = employee.GetComponent<My_CV>().e_Name;
        empPicture.GetComponent<Image>().sprite = employee.GetComponent<My_CV>().e_EmployeeFoto;
        empHappiness.GetComponent<Slider>().value = employee.GetComponent<My_CV>().e_Happiness;
        //Change Interactablity for happiness slider
        empEfficiency.GetComponent<Slider>().value = employee.GetComponent<My_CV>().e_Efficientcy;
        //Change Interactablity for the efficientcy slider
        empProductivity.GetComponent<Slider>().value = employee.GetComponent <My_CV>().e_Productivity;
        //Change interactability for the productivity slider
        empBiography.GetComponent<TMP_Text>().text = employee.GetComponent<My_CV>().e_bio;
        
        for(int i = 0; i < employee.GetComponent<My_CV>().e_skills.Count; i++)
        {
            empSkill.GetComponent<TMP_Text>().text += i + 1 + employee.GetComponent<My_CV>().e_skills[i] + "\n";
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

    public void ResetEmployee()
    {
        empName.GetComponent<Text>().text = "";
        empPicture.GetComponent<Image>().sprite = null;
        empHappiness.GetComponent<Slider>().value = 0;
        empEfficiency.GetComponent<Slider>().value = 0;
        empProductivity.GetComponent<Slider>().value = 0;
        empBiography.GetComponent<TMP_Text>().text = "";
        empSkill.GetComponent<TMP_Text>().text = "";
        empEducation.GetComponent<TMP_Text>().text = "";
        empWorkExperience.GetComponent<TMP_Text>().text = "";

        SetCV(Employee_Manager.instance.listUnEmployees[0]);
    }
}
