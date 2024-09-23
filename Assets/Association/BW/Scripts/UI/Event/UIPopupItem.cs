using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UIPopupItem : UIEvent
{
    public bool isPointerSizeUp = true;
    public PopupType popupType;

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (isPointerSizeUp) {
            DOTween.Kill(rect);
            rect.DOScale(1.1f, .2f);
        }
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        if (isPointerSizeUp) {
            DOTween.Kill(rect);
            rect.DOScale(1f, .2f);
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        PopupManager.instance.Open(popupType);
    }
}