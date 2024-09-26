using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class MinimizeSkill : UIButtonItem, IMinimizeToggle
{
    public bool IsMinimize { get; set; }
    [field : SerializeField] public Image Image { get; set; }
    [field : SerializeField] public RectTransform MinimizetTarget { get; set; }
    public float MinimizeTime { get; set; } = .5f;
    private Vector2 originalSize;

    protected override void Awake()
    {
        base.Awake();
        originalSize = MinimizetTarget.rect.size;
    }
    
    public override void OnClick(PointerEventData eventData)
    {
        MinimizetTarget.DOKill();
        Image.transform.DOKill();

        if (IsMinimize) Maximize();
        else Minimize();
    }

    public void Maximize()
    {
        MinimizetTarget.DOSizeDelta(originalSize, MinimizeTime).SetEase(Ease.OutBack);
        Image.transform.DOScaleX(1f, .2f).SetDelay(MinimizeTime * 0.7f);
        IsMinimize = false;
    }

    public void Minimize()
    {
        MinimizetTarget.DOSizeDelta(new Vector2(0f, originalSize.y), MinimizeTime).SetEase(Ease.InBack);
        Image.transform.DOScaleX(-1f, .2f).SetDelay(MinimizeTime);
        IsMinimize = true;
    }
}
