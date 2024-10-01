using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class MinimizeSkill : UIButton, IMinimizeToggle
{
    public bool isMinimize { get; set; }
    public float minimizeTime { get; set; } = .5f;
    [field : SerializeField] public Image image { get; set; }
    [field : SerializeField] public RectTransform minimizetTarget { get; set; }

    private Vector2 originalSize;

    protected override void Awake()
    {
        base.Awake();
        originalSize = minimizetTarget.rect.size;
    }
    
    public override void OnClick(PointerEventData eventData)
    {
        minimizetTarget.DOKill();
        image.transform.DOKill();

        if (isMinimize) Maximize();
        else Minimize();
    }

    public void Maximize()
    {
        minimizetTarget.DOSizeDelta(originalSize, minimizeTime).SetEase(Ease.OutBack);
        image.transform.DOScaleX(1f, minimizeTime / 2).SetDelay(minimizeTime / 2);
        isMinimize = false;
    }

    public void Minimize()
    {
        minimizetTarget.DOSizeDelta(new Vector2(0f, originalSize.y), minimizeTime).SetEase(Ease.InBack);
        image.transform.DOScaleX(-1f, minimizeTime / 2).SetDelay(minimizeTime);
        isMinimize = true;
    }
}
