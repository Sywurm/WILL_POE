using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CV", menuName = "Create SO/New CV", order = 0)]
public class CV_SO : ScriptableObject
{
    //Blueprint for employees
    //add more stats here to add every where
    public string e_Name;
    public Employee_Stats.attitude e_Attitude;
    public Employee_Stats.skill skill;
    public Employee_Stats.workExp workExp;
    //public float e_Happiness;
    public int e_Efficientcy;
    public int e_Productivity;
}
