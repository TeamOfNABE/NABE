using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;


public class UIPopupItem : UIEvent
{
    public bool isPointerSizeUp = true;

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (isPointerSizeUp) {
            rect.DOScale(1.1f, .2f);
        }
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        if (isPointerSizeUp) {
            rect.DOScale(1f, .2f);
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Popup");
    }
}