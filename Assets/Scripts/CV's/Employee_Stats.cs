using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee_Stats : MonoBehaviour
{
    //When adding more stats here also add it to CV_SO.cs
    public enum attitude
    {
        //Add more Moods here
        none,
        happy,
        angry
    }

    public enum skill
    {
        //Add skills for the employee
        none,
    }

    public enum workExp
    {
        //Add previous work experience
        None,
    }
}
