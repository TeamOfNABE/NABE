using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class MinimizeStatus : UIButtonItem, IMinimizeToggle
{
    public bool IsMinimize { get; set; }
    [field : SerializeField] public Image Image { get; set; }
    [field : SerializeField] public RectTransform MinimizetTarget { get; set; }
    
    public float MinimizeTime { get; set; } = .5f;
    private Vector2 originalSize;

    [Space(20f)]
    [SerializeField] private RectTransform hideTarget;
    [SerializeField] private RectTransform[] invisibleTarget;
    private CanvasGroup[] invisibleCanvasGroup;

    protected override void Awake()
    {
        base.Awake();
        originalSize = MinimizetTarget.rect.size;

        invisibleCanvasGroup = new CanvasGroup[invisibleTarget.Length];
        for (int i = 0; i < invisibleTarget.Length; ++i) {
            invisibleCanvasGroup[i] = invisibleTarget[i].AddComponent<CanvasGroup>();
        }
    }

    public override void OnClick(PointerEventData eventData)
    {
        if (IsMinimize) Maximize();
        else Minimize();
    }

    public void Maximize()
    {
        DOTween.To(() => MinimizetTarget.rect.height, x => MinimizetTarget.sizeDelta = new Vector2(0, x), originalSize.y, MinimizeTime);
        foreach (var item in invisibleTarget) {
            item.GetComponent<CanvasGroup>().DOFade(1f, MinimizeTime);
        }
        IsMinimize = false;
    }

    public void Minimize()
    {
        DOTween.To(() => MinimizetTarget.rect.height, x => MinimizetTarget.sizeDelta = new Vector2(0, x), originalSize.y - hideTarget.sizeDelta.y, MinimizeTime);
        foreach (var item in invisibleTarget) {
            item.GetComponent<CanvasGroup>().DOFade(0f, MinimizeTime);
        }
        IsMinimize = true;
    }
}