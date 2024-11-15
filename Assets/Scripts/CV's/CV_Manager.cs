using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class CV_Manager : MonoBehaviour
{
    [SerializeField] private GameObject empSkillPrefab;

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
            empSkill.GetComponent<Text>().text = i + 1 + "." + employee.GetComponent<My_CV>().e_skills[i].ToString();
            // Instantiate(empSkill, empSkillList.transform);
        }        

        for(int i = 0; i < employee.GetComponent<My_CV>().e_edu.Count; i++)
        {
            empEducation.GetComponent<TMP_Text>().text = employee.GetComponent<My_CV>().e_edu[i].ToString();
        }

        for (int i = 0; i< employee.GetComponent<My_CV>().e_workExp.Count; i++)
        {
            empWorkExperience.GetComponent<TMP_Text>().text = employee.GetComponent<My_CV>().e_workExp[i].ToString();
        }
    }
}
