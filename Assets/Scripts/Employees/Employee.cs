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
