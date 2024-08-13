using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="DebugLogLevel", menuName ="Create SO/DebugLogLevel", order = 1)]
public class DebugLogLevel_SO : ScriptableObject
{
    public LogLevelManager.LogLevel DebugLogLevel = (LogLevelManager.LogLevel)0;
}
