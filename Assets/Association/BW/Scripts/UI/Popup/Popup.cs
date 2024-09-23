using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public enum PopupEffectType
{
    // Scale
    Defualt, // 기본 확장 팝업

    // Move
    UpToDown, // 위에서 아래로 내려오는 팝업
    DownToUp,
    LeftToRight,
    RightToLeft,
}

public class Popup : MonoBehaviour
{
    private RectTransform rect;
    private CanvasGroup canvasGroup;
    public PopupEffectType popupEffectType;

    [Tooltip("체크 시 배경 딤드처리(배경 클릭 Off)")] public bool isDimmed = true;
    private string dimmedPath = "Prefabs/UI/Popup/Dimmed";
    

    private void Awake()
    {
        // Get Reference
        rect = GetComponent<RectTransform>();
        rect.SetParent(MainCanvas.instance.transform, false);

        canvasGroup = GetComponent<CanvasGroup>();

        // Setting Dimmed
        if (isDimmed) SettingDimmed();

        // Setting UI Animation
        if (popupEffectType <= PopupEffectType.Defualt) { // Scalse To Zero
            rect.localScale = Vector2.zero;
        }
        else if (popupEffectType <= PopupEffectType.RightToLeft) { // Move To Out Of Sight
            switch (popupEffectType) {
                case PopupEffectType.UpToDown :
                    rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y + 200f);
                    break;
                case PopupEffectType.DownToUp :
                    rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y - 200f);
                    break;
                case PopupEffectType.LeftToRight :
                    rect.anchoredPosition = new Vector2(rect.anchoredPosition.x - 200f, rect.anchoredPosition.y);
                    break;
                case PopupEffectType.RightToLeft :
                    rect.anchoredPosition = new Vector2(rect.anchoredPosition.x + 200f, rect.anchoredPosition.y);
                    break;
            }
            canvasGroup.alpha = 0f;
        }
    }

    /// <summary>
    /// Setting Dimmed
    /// </summary>
    private void SettingDimmed()
    {
        Dimmed dimmed = Instantiate(Resources.Load<Dimmed>(dimmedPath), MainCanvas.instance.transform, false);
        this.transform.SetParent(dimmed.transform, false);
    }

    /// <summary>
    /// UI Open Popup Animation
    /// </summary>
    public void OpenPopup(Action openCompleteAction = null)
    {
        PopupEffect(popupEffectType, openCompleteAction : openCompleteAction);
    }
    
    /// <summary>
    /// UI Close Popup Animation
    /// </summary>
    public void ClosePopup(Action closeCompleteAction = null)
    {
        PopupEffect(popupEffectType, isOpen : false, openCompleteAction : closeCompleteAction);
    }

    private void PopupEffect(PopupEffectType popupEffectType, bool isOpen = true, Action openCompleteAction = null)
    {
        switch (popupEffectType) {
            // Move
            case >= PopupEffectType.UpToDown :
                if (isOpen) { OpenMoveAnimation(popupEffectType, Ease.OutBounce, openCompleteAction); }
                else { CloseMoveAnimation(popupEffectType, Ease.OutQuad, openCompleteAction); }
                break;
            // Scale
            default : // PopupEffectType.Defualt
                if (isOpen) { OpenScaleAnimation(Ease.OutBack, openCompleteAction); }
                else { CloseScaleAnimation(Ease.InBack, openCompleteAction); }
                break;
        }
    }

    // Scale Open
    private void OpenScaleAnimation(Ease ease, Action openCompleteAction = null)
    {
        DOTween.Kill(rect);
        rect.localScale = Vector2.zero;
        rect.DOScale(1f, .5f).SetEase(ease)
            .OnComplete(() => { openCompleteAction?.Invoke(); });
    }

    // Scale Close
    private void CloseScaleAnimation(Ease ease, Action closeCompleteAction = null)
    {
        DOTween.Kill(rect);
        rect.DOScale(0.1f, .5f).SetEase(ease)
            .OnComplete(() => { rect.localScale = Vector2.zero;  closeCompleteAction?.Invoke(); });
    }

    // Move Open
    private void OpenMoveAnimation(PopupEffectType direction, Ease ease, Action openCompleteAction = null)
    {
        DOTween.Kill(rect);
        DOTween.Kill(canvasGroup);
        Sequence sequence = DOTween.Sequence();

        switch (direction) {
            case PopupEffectType.UpToDown :
            case PopupEffectType.DownToUp :
                sequence.Append(rect.DOAnchorPosY(0f, .5f)).SetEase(ease);
                break;
            case PopupEffectType.LeftToRight :
            case PopupEffectType.RightToLeft :
                sequence.Append(rect.DOAnchorPosX(0f, .5f)).SetEase(ease);
                break;
        }
        sequence.Join(canvasGroup.DOFade(1f, .5f));
        sequence.OnComplete(() => { openCompleteAction?.Invoke(); });
    }

    // Move Close
    private void CloseMoveAnimation(PopupEffectType direction, Ease ease, Action closeCompleteAction = null)
    {
        DOTween.Kill(rect);
        DOTween.Kill(canvasGroup);
        Sequence sequence = DOTween.Sequence();
    
        switch (direction) {
            case PopupEffectType.UpToDown :
                sequence.Append(rect.DOAnchorPosY(200f, .5f)).SetEase(ease);
                break;
            case PopupEffectType.DownToUp :
                sequence.Append(rect.DOAnchorPosY(-200f, .5f)).SetEase(ease);
                break;
            case PopupEffectType.LeftToRight :
                sequence.Append(rect.DOAnchorPosX(-200f, .5f)).SetEase(ease);
                break;
            case PopupEffectType.RightToLeft :
                sequence.Append(rect.DOAnchorPosX(200f, .5f)).SetEase(ease);
                break;
        }
        sequence.Join(canvasGroup.DOFade(0f, .5f));
        sequence.OnComplete(() => { closeCompleteAction?.Invoke(); });
    }
}