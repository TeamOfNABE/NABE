using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class MinimizeStatus : UIButton, IMinimizeToggle
{
    public bool isMinimize { get; set; }
    public float minimizeTime { get; set; } = .5f;
    [field : SerializeField] public Image image { get; set; }
    [field : SerializeField] public RectTransform minimizetTarget { get; set; }

    [Space(20f)]
    private Vector2 originalSize;
    [SerializeField] private RectTransform hideTarget;
    [SerializeField] private RectTransform[] invisibleTarget;
    private CanvasGroup[] invisibleCanvasGroup;
    public MinimizeQuick minimizeQuick;

    protected override void Awake()
    {
        base.Awake();
        originalSize = minimizetTarget.rect.size;

        invisibleCanvasGroup = new CanvasGroup[invisibleTarget.Length];
        for (int i = 0; i < invisibleTarget.Length; ++i) {
            invisibleCanvasGroup[i] = invisibleTarget[i].AddComponent<CanvasGroup>();
        }
    }

    public override void OnClick(PointerEventData eventData)
    {
        minimizetTarget.DOKill();
        image.transform.DOKill();
        foreach (var item in invisibleCanvasGroup) item.DOKill();

        if (isMinimize) Maximize();
        else Minimize();
    }

    public void Maximize()
    {
        DOTween.To(() => minimizetTarget.rect.height, x => minimizetTarget.sizeDelta = new Vector2(0, x), originalSize.y, minimizeTime);
        image.transform.DOScaleY(1f, minimizeTime / 2).SetDelay(minimizeTime);
        foreach (var item in invisibleCanvasGroup) {
            item.DOFade(1f, minimizeTime);
        }
        minimizeQuick.Maximize();
        isMinimize = false;
    }

    public void Minimize()
    {
        DOTween.To(() => minimizetTarget.rect.height, x => minimizetTarget.sizeDelta = new Vector2(0, x), originalSize.y - hideTarget.sizeDelta.y, minimizeTime);
        image.transform.DOScaleY(-1f, minimizeTime / 2).SetDelay(minimizeTime / 2);
        foreach (var item in invisibleCanvasGroup) {
            item.DOFade(0f, minimizeTime);
        }
        minimizeQuick.Minimize();
        isMinimize = true;
    }
}