using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Variables
    #region OfficeStates
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
    [SerializeField][Range(8, 17)] private int hour = 8;
    [SerializeField] private int minuets = 00;
    [SerializeField][Range(1, 5)] private int day = 0;

    [SerializeField] bool timeIsPaused = false;

    [SerializeField] TextMeshProUGUI TimeTMP;
    [SerializeField] TextMeshProUGUI HourTMP;
    [SerializeField] TextMeshProUGUI DayTMP;

    private enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
    }
    private DayOfWeek dayOfWeek;

    #endregion

    #endregion

    #region Unity Functions
    // Start is called before the first frame update
    void Start()
    {
        timeIsPaused = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Space Pressed");
            if (timeIsPaused == false)
            {
                Debug.Log("Time Paused");
                timeIsPaused = true;
            }
            else if (timeIsPaused == true)
            {
                Debug.Log("Time unPaused");
                timeIsPaused = false;
            }
        }
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
        if (timeIsPaused == false)
        {
            currentTime = seconds * multiplier;
            seconds += Time.fixedDeltaTime;
        }
        else
        {
            
        }


        if(currentTime >= 30f)
        {
            seconds = 0f;
            currentTime = 0f;

            hour +=1;
        }

        if(currentTime >= 16 )
        {
            minuets = 30;
        }
        else 
        {
            minuets = 00;
        }

        if(hour >= 17 )
        {
            hour = 8;
            day += 1;
        }

        switch (day)
        {
            case 1:
                dayOfWeek = DayOfWeek.Monday;
                break;
            case 2:
                dayOfWeek = DayOfWeek.Tuesday;
                break;
            case 3:
                dayOfWeek = DayOfWeek.Wednesday;
                break;
            case 4:
                dayOfWeek = DayOfWeek.Thursday;
                break;
            case 5:
                dayOfWeek = DayOfWeek.Friday;
                break;
                default:
                dayOfWeek = DayOfWeek.Monday;
                break;

        }

        TimeTMP.text = ((int)currentTime).ToString();
        HourTMP.text = $"{(int)hour} : {(minuets).ToString("D2")}";
        DayTMP.text = dayOfWeek.ToString();
    }


    #endregion

    #endregion



}
