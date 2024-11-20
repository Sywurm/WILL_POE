using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class My_CV : MonoBehaviour
{
    [Header("List of available Items", order = 0)]
    [SerializeField] private List<string> names;
    [SerializeField] private List<string> biography;
    [SerializeField] private List<string> education;
    [SerializeField] private List<string> skills;
    [SerializeField] private List<string> workExp;

    [Header("Employee Stats:", order = 1)]
    public string e_Name;
    public Employee.EmployeeAttitudeType e_Attitude;
    public Employee.EmployeePosition e_position;
    public Sprite e_EmployeeFoto;
    public bool e_IsHired;

    public string e_bio;
    public List<string> e_edu;
    public List<string> e_skills;
    public List<string> e_workExp;

    public float e_Happiness;
    public float e_Efficientcy;
    public float e_Productivity;

    private void Awake()
    {
        //Randomise Names
        int rngName = Random.Range(0, names.Count);
        e_Name = names[rngName];
        //chooses random Attitude
        int rngAttitude = Random.Range(0, 6);
        switch (rngAttitude)
        {
            case 0:
                e_Attitude = Employee.EmployeeAttitudeType.Chill; break;
            case 1:
                e_Attitude = Employee.EmployeeAttitudeType.Motivated; break;
            case 2:
                e_Attitude = Employee.EmployeeAttitudeType.Productive; break;
            case 3:
                e_Attitude = Employee.EmployeeAttitudeType.Annoying; break;
            case 4:
                e_Attitude = Employee.EmployeeAttitudeType.Confrontational; break;
            case 5:
                e_Attitude = Employee.EmployeeAttitudeType.DeadWeight; break;
        }

        e_position = Employee.EmployeePosition.Unassigned;

        //randomise Bio
        int rngBio = Random.Range(0, biography.Count);
        e_bio = biography[rngBio];

        //Randomise Education
        int randomAmount = Random.Range(1,education.Count);
        for (int i = 0; i < randomAmount; i++)
        {
            int rngEducation = Random.Range(0, education.Count);
            if (!e_edu.Contains(education[rngEducation]))
            {
                e_edu.Add(education[rngEducation]);
            }
        }

        //Randomise Skills
        randomAmount = Random.Range(1,skills.Count);
        for(int i = 0;i < randomAmount;i++)
        {
            int rngSkills = Random.Range(0,skills.Count);
            if (!e_skills.Contains(skills[rngSkills]))
            {
                e_skills.Add(skills[rngSkills]);
            }
        }

        //Randomise Work experience
        //randomAmount = Random.Range(0, workExp.Count);
        int rngWorkExp = Random.Range(0, workExp.Count);
        if (!e_workExp.Contains(workExp[rngWorkExp]))
        {
            e_workExp.Add(workExp[rngWorkExp]);
        }

        float rngHappy = Random.Range(0, 100);
        e_Happiness = rngHappy;

        float rngEfficientcy = Random.Range(0, 100);
        e_Efficientcy = rngEfficientcy;

        float rngProductivity = Random.Range(0, 100);
        e_Productivity = rngProductivity;
    }
}