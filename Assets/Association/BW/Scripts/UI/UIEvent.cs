using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEvent : IPointerClickHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerClick(PointerEventData eventData) // Click
    {
        Debug.Log("Click");
    }
    
    public void OnDrag(PointerEventData eventData) // Drag
    {
        Debug.Log("Drag");
    }
    
    public void OnPointerEnter(PointerEventData eventData) // Enter
    {
        Debug.Log("Enter");
    }
    
    public void OnPointerExit(PointerEventData eventData) // Exit
    {
        Debug.Log("Exit");
    }
}
