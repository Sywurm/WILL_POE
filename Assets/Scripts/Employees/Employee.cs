using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Employee
{
    //A list of employee atitudes
    public enum EmployeeAttitudeType
    {
        Chill,
        Motivated,
        Productive,
        Annoying,
        Confrontational,
        DeadWeight
    }

    //A list of departments for the employees to work at.
    public enum EmployeePosition
    {
        Unassigned = 0,
        GameDesign,
        GameArt,
        GameDevelopment,
        OpperationsDepartment,
        NarrativeDepartment,
        MarketingDepartment,
        FinanceDepartment,
        QualityAssuranceDepartment
    }
}
