using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee_Stats : MonoBehaviour
{
    //When adding more stats here also add it to CV_SO.cs
    // A list of attitudes to display
    public enum attitude
    {
        //Add more Moods here
        none,
        happy,
        angry
    }

    // A list of skills
    public enum skill
    {
        //Add skills for the employee
        none,
    }

    // A list of work Experience
    public enum workExp
    {
        //Add previous work experience
        None,
    }
}
