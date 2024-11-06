using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Employee
{
  public enum EmployeeAttitudeType
    {
        Chill,
        Motivated,
        Productive,

        Annoying,
        Confrontational,
        DeadWeight
    }

    public enum EmployeePosition
    {
        Unassigned,
        GameDesign,
        GameArt,
        GameDevelopment,
        Opperations,
        Narrative,
        Marketing,
        Finace,
        QualityAssurance
    }
}
