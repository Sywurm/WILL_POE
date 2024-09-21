using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_CV : MonoBehaviour
{
    public CV_SO goodCV;
    public CV_SO badCV;
    public bool createGoodCV;
    public bool createBadCV;

    [Header("Settings",order = 0)]
    public GameObject employeePicture;
    public GameObject employeeName;
    public GameObject employeeSkillsList;
    public GameObject employeeSkill;
    public GameObject employeeBiography;
    public GameObject employeeEducation;
    public GameObject employeeWorkExperience;

    private void Update()
    {
        if (createGoodCV)
        {
            GoodCV();
            createGoodCV = false;
        }

        if (createBadCV)
        {
            BadCV();
            createBadCV = false;
        }
    }

    public void GoodCV()
    {
        employeePicture.GetComponent<Image>().sprite = goodCV.e_EmployeeFoto;
        employeeName.GetComponent<Text>().text = goodCV.e_Name;
        for (int i = 0;i < goodCV.skills.Count; i++)
        {
            employeeSkill.GetComponent<Text>().text = i + 1 + "." + goodCV.skills[i].ToString();
            Instantiate(employeeSkill, employeeSkillsList.transform);
        }
        employeeBiography.GetComponent<TMP_Text>().text = goodCV.biography;
        for (int i = 0; i < goodCV.education.Count; i++)
        {
            employeeEducation.GetComponent<TMP_Text>().text += goodCV.education[i];
        }

        for (int i = 0; i < goodCV.workExp.Count; i++)
        {
            employeeWorkExperience.GetComponent<TMP_Text>().text += goodCV.workExp[i];
        }
    }

    public void BadCV()
    {
        employeePicture.GetComponent<Image>().sprite = badCV.e_EmployeeFoto;
        employeeName.GetComponent<Text>().text = badCV.e_Name;
        for(int i = 0; i < badCV.skills.Count; i++)
        {
            employeeSkill.GetComponent<Text>().text = i + 1 + "." + badCV.skills[i].ToString();
            Instantiate(employeeSkill, employeeSkillsList.transform);
        }
        employeeBiography.GetComponent<TMP_Text>().text = badCV.biography;
        for (int i = 0; i < badCV.education.Count; i++)
        {
            employeeEducation.GetComponent<TMP_Text>().text += badCV.education[i];
        }

        for (int i = 0; i < badCV.workExp.Count; i++)
        {
            employeeWorkExperience.GetComponent<TMP_Text>().text += badCV.workExp[i];
        }
    }
}
