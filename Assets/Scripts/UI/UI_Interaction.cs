using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class UI_Interaction : MonoBehaviour
{
    public GameObject UICanvas;

    GraphicRaycaster ui_raycaster;


    PointerEventData clickData;
    List<RaycastResult> results;

    void Start()
    {
        ui_raycaster = UICanvas.GetComponent<GraphicRaycaster>();
        clickData = new PointerEventData(EventSystem.current);
        results = new List<RaycastResult>();
    }


    void Update()
    {
        if(Mouse.current.leftButton.wasReleasedThisFrame)
        {
            GetUIElementsClicked();
        }
    }

    private void GetUIElementsClicked()
    {
        clickData.position = Mouse.current.position.ReadValue();
        results.Clear();

        ui_raycaster.Raycast(clickData, results);

        foreach(RaycastResult result in results)
        {
            GameObject ui_element = result.gameObject;
            Debug.Log(ui_element.name);


        }

        
    }
}
