using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    #region OfficeStates
    //This is a list of employees, this list will be updated by the emplyoeeManager as a new emploee is hired or fired
    private List<GameObject> listOfActiveEmployees;

    //These Variables are the current office stats that will be seen on the UI.
    [Tooltip("This Value Represents the Office happiness. It can only be reAssigned from within this script ")]
    [SerializeField] private float OfficeHappitness;

    [Tooltip("This Value Represents the Office Efficiency. It can only be reAssigned from within this script ")]
    [SerializeField] private float OfficeEfficiency;

    [Tooltip("This Value Represents the Office State. It can only be reAssigned from within this script ")]
    [SerializeField] private float OfficeState;

    [Tooltip("This Value is public so other elements such as UI can access it ")]
    public float _OfficeHappitness;

    [Tooltip("This Value is public so other elements such as UI can access it ")]
    public float _OfficeEfficiency;

    [Tooltip("This Value is public so other elements such as UI can access it ")]
    public float _OfficeState;
    #endregion

    #region TimeManagement
    [SerializeField][Range(0,60)] private float seconds = 0f;
    [SerializeField][Range(0, 60)] private float currentTime = 0f;
    [SerializeField] private float multiplier = 1f;
    [SerializeField][Range(0, 24)] private int hour = 00;
    [SerializeField][Range(0, 5)] private int day = 0;

    #endregion

    #endregion

    #region Unity Functions
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimeManager();
    }
    #endregion

    #region Functions

    #region TimeFunctions

    private void TimeManager()
    {
        currentTime = seconds * multiplier;
        seconds += Time.fixedDeltaTime;

        if(currentTime >= 60f)
        {
            seconds = 0f;
            currentTime = 0f;

            hour++;
        }

        if(hour >= 24 )
        {
            hour = 0;
            day++;
        }
    }

    #endregion

    private void OfficeStats()
    {
        //Setting these States so that they can be used by the UI elements.
        _OfficeHappitness = OfficeHappitness;
        _OfficeEfficiency = OfficeEfficiency;
        _OfficeState = OfficeState;
    }


    #endregion



}
