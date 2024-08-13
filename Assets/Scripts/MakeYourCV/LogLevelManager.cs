using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogLevelManager : MonoBehaviour
{
    public enum LogLevel 
    {
        INFO = 0,
        WARNING,
        ERROR
    }

    [SerializeField] private DebugLogLevel_SO m_DebugLevel;
   
    public static LogLevelManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

    public void Log(string message, LogLevel logLevel)
    {
        switch (logLevel)
        {
            case LogLevel.INFO:
                if ((int)m_DebugLevel.DebugLogLevel <= (int)LogLevel.INFO) Debug.Log($"[INFO]: {message}");
                break;
            case LogLevel.WARNING:
                if ((int)m_DebugLevel.DebugLogLevel <= (int)LogLevel.WARNING) Debug.Log($"[WARNING]: {message}");
                break;
            case LogLevel.ERROR:
                if ((int)m_DebugLevel.DebugLogLevel <= (int)LogLevel.ERROR) Debug.Log($"[ERROR]: {message}");
                break;
            default:
                break;
        }
    }
}
