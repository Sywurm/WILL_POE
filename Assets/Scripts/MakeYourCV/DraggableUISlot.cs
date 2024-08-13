using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUISlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableUIImage draggableItem = dropped.GetComponent<DraggableUIImage>();
            draggableItem.parentAfterDrag = transform;
        }
        else
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableUIImage draggableItem = dropped.GetComponent<DraggableUIImage>();

            GameObject current = transform.GetChild(0).gameObject;
            DraggableUIImage currentDraggable = current.GetComponent<DraggableUIImage>();

            currentDraggable.transform.SetParent(draggableItem.parentAfterDrag);
            draggableItem.parentAfterDrag = transform;
        }
    }
}
