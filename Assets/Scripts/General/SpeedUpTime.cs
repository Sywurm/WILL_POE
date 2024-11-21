using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpeedUpTime : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Time.timeScale = 10;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Time.timeScale = 1;
    }
}
