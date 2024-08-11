using UnityEngine;

public class Employee : MonoBehaviour
{
    #region General Variables

    [Tooltip("This is a true/false bool that represents whether the employee is actively employed or not, there are seperate functions that can be used to change its value ")]
    [SerializeField] private bool isActivelyEmployed;

    [Tooltip("This Value Represents this employees Affect on this major 'progress bar' ")]
    [SerializeField] private float employeeHappiness;

    [Tooltip("This Value Represents this employees Affect on this major 'progress bar' ")]
    [SerializeField] private float employeeEfficiency;

    [Tooltip("This Value Represents this employees Affect on this major 'progress bar' ")]
    [SerializeField] private float employeeOfficeEffect;

    public enum EmployeeAttitudeType
    {
        Chill,
        Motivated,
        Productive,

        Annoying,
        Confrontational,
        DeadWeight
    }
    [Tooltip("This is a public enum that allows for employee Attitude to be assinged and changed from anywhere")]
    public EmployeeAttitudeType attitudeType;

    //Assign the Employee Previous Work Experience in inspector
    [Tooltip("Assign Each Work Expereince in a seperate element of the array")]
    public string[] previousWorkExperience;

    //Assign the Employee Skills in inspector
    [Tooltip("Assign Each Skill in a seperate element of the array")]
    public string[] currentSkills;

    #endregion

    #region UnityFunctions

    private void Start()
    {

    }

    private void Update()
    {
        
    }

    #endregion

    #region Functions

    #region EmployeeStats

    private float AssignRandomStats(float stat)
    {
        //Roll a Random Number Each time this function is called to assign that number as a stat
        float statAssignment = 0;
        statAssignment = Random.Range(0, 101);

        return statAssignment;
    }

    //Function that rolls a random number using a generator function to assign the employees Stats
    private void AssignHappiness()
    {
        employeeHappiness = AssignRandomStats(employeeHappiness);

    }

    //Function that rolls a random number using a generator function to assign the employees Stats
    private void AssignEfficiency()
    {
        employeeEfficiency = AssignRandomStats(employeeEfficiency);
    }

    //Function that rolls a random number using a generator function to assign the employees Stats
    private void AssignOfficeEffect()
    {
        employeeOfficeEffect = AssignRandomStats(employeeOfficeEffect);
    }


    #endregion

    #region Employment Status

    //Public Functions that can be used to change employee Employment Status
    public void IsEmployed()
    {
        isActivelyEmployed = true;
    }

    //Public Functions that can be used to change employee Employment Status
    public void IsNotEmployed()
    {
        isActivelyEmployed = false;
    }

    #endregion

    #endregion


}
