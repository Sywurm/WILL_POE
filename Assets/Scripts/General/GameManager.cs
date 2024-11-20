using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.GlobalIllumination;

public class GameManager : MonoBehaviour
{
    #region Variables
    public static GameManager instance;

    #region OfficeStates
    [Tooltip("This Value Represents the x rotation of the directional light (Sun).")]
    [SerializeField][Range(0, 180)] private float sunRotationX;

    [Tooltip("This Value is public so other elements such as UI can access it ")]
    public float _OfficeHappiness;

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

    [SerializeField] GameObject sun;

    private enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
    }
    private DayOfWeek dayOfWeek;
    #region SunManagement

    private float startTime = 8f;
    private float endTime = 17f;
    private float intialRotation = 0f;
    private float finalRotation = 180f;

    private float currentRotation;
    private float currentHour;




    #endregion

    #endregion

    #endregion

    #region Unity Functions
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeIsPaused = false;
        sun.transform.localEulerAngles = new Vector3(currentRotation, 0, 0);
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
        RotateDirectionalLight();



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

        //Note Time Text is for developer debugging to show how long a day is. 
        //Time Text is not required for players to be able to play the game.
        if(TimeTMP != null)
        {
            TimeTMP.text = ((int)currentTime).ToString();
        }
        else
        {
            Debug.Log("No Time Text Present");
        }
        HourTMP.text = $"{(int)hour} : {(minuets).ToString("D2")}";
        DayTMP.text = dayOfWeek.ToString();
    }


    #endregion

    #region SunFunctions
    private void RotateDirectionalLight()
    {
        //This switch case rotates the sun according to the hour using the seconds as the lerp time.
        //The rotation happens over 15 seconds during specified time changing hours.
        switch(hour)
        {
            case 8:

                currentRotation = Mathf.Lerp(0, 15, currentTime / 15);
                sun.transform.rotation = Quaternion.Euler(currentRotation, 0, 0);
                break;
            case 10:
                currentRotation = Mathf.Lerp(15, 45, currentTime / 15);
                sun.transform.rotation = Quaternion.Euler(currentRotation, 0, 0);
                break;

            case 12:
                currentRotation = Mathf.Lerp(45, 90, currentTime / 15);
                sun.transform.rotation = Quaternion.Euler(currentRotation, 0, 0);
                break;

            case 14:
                currentRotation = Mathf.Lerp(90, 135, currentTime / 15);
                sun.transform.rotation = Quaternion.Euler(currentRotation, 0, 0);
                break;

            case 16:
                currentRotation = Mathf.Lerp(135, 170, currentTime / 15);
                sun.transform.rotation = Quaternion.Euler(currentRotation, 0, 0);
                break;
        }
    }
    #endregion

    #endregion



}
