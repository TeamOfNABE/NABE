using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System;

public class UIButton : UIItem
{
    public bool isPointerSizeUp = true;

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
        Debug.Log("Click");
    }
}
