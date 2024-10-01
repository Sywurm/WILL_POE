using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class My_CV : MonoBehaviour
{
    [Header("List of available Items", order = 0)]
    public List<string> names;
    public List<string> biography;
    public List<string> education;
    public List<string> skills;
    public List<string> workExp;

    [Header("Employee Stats:", order = 1)]
    public string e_Name;
    public Employee.EmployeeAttitudeType e_Attitude;
    public Sprite e_EmployeeFoto;

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
        //randomise Bio
        int rngBio = Random.Range(0, biography.Count);
        e_bio = biography[rngBio];
        //Randomise Education
        int randomAmount = Random.Range(0,education.Count);
        for (int i = 0; i < randomAmount; i++)
        {
            int rngEducation = Random.Range(0, education.Count);
            e_edu.Add(education[rngEducation]);
        }
        //Randomise Skills
        randomAmount = Random.Range(0,skills.Count);
        for(int i = 0;i < randomAmount;i++)
        {
            int rngSkills = Random.Range(0,skills.Count);
            e_skills.Add(skills[rngSkills]);
        }
        //Randomise Work experience
        randomAmount = Random.Range(0, workExp.Count);
        for( int i = 0;i<randomAmount ; i++)
        {
            int rngWorkExp = Random.Range(0, workExp.Count);
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