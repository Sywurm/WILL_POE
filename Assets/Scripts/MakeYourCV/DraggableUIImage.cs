using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableUIImage : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Image image;
    public Transform parentAfterDrag;
    public bool currentlyDraggable = true;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!currentlyDraggable) return;

        LogLevelManager.instance.Log("Begin drag", LogLevelManager.LogLevel.INFO);
        parentAfterDrag = transform.parent;

        // Changing the parent to the canvas and moving it in the hierarchy so that it is visible over everything
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!currentlyDraggable) return;

        LogLevelManager.instance.Log("Dragging", LogLevelManager.LogLevel.INFO);
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!currentlyDraggable) return;

        LogLevelManager.instance.Log("End drag", LogLevelManager.LogLevel.INFO);

        // Resetting the parent back to its initial parent
        transform.SetParent(parentAfterDrag);

        image.raycastTarget = true;
    }
}
