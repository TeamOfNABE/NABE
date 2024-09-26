using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System;

public class UIPopupItem : UIEvent
{
    public bool isPointerSizeUp = true;
    public PopupType popupType;

    public override void OnEnter(PointerEventData eventData)
    {
        if (isPointerSizeUp) {
            DOTween.Kill(rect);
            rect.DOScale(1.1f, .2f);
        }
    }

    public override void OnExit(PointerEventData eventData)
    {
        if (isPointerSizeUp) {
            DOTween.Kill(rect);
            rect.DOScale(1f, .2f);
        }
    }

    public override void OnClick(PointerEventData eventData)
    {
        PopupManager.instance.Open(popupType);
    }
}