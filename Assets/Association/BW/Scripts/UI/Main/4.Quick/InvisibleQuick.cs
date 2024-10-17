using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using Unity.VisualScripting;

public class InvisibleQuick : UIButton, IMinimizeToggle
{
    public bool isMinimize { get; set; }
    public float minimizeTime { get; set; } = .5f;
    [field : SerializeField] public Image image { get; set; }
    [field : SerializeField] public RectTransform minimizetTarget { get; set; }

    [SerializeField] private RectTransform[] invisibleTarget;
    private CanvasGroup[] invisibleCanvasGroup;
    private UIPopup[] uIPopups;

    protected override void Awake()
    {
        base.Awake();
        invisibleCanvasGroup = new CanvasGroup[invisibleTarget.Length];
        uIPopups = new UIPopup[invisibleTarget.Length];
        for (int i = 0; i < invisibleTarget.Length; ++i) {
            invisibleCanvasGroup[i] = invisibleTarget[i].AddComponent<CanvasGroup>();
            uIPopups[i] = invisibleTarget[i].GetComponent<UIPopup>();
        }
        
    }

    public override void OnClick(PointerEventData eventData)
    {
        image.transform.DOKill();
        foreach (var item in invisibleTarget) item.DOKill();
        foreach (var item in invisibleCanvasGroup) item.DOKill();

        if (isMinimize) Maximize();
        else Minimize();
    }

    public void Maximize()
    {
        image.transform.DOScaleY(1f, minimizeTime / 2).SetDelay(minimizeTime / 2);
        
        for (int i = 0; i < invisibleTarget.Length; ++i) {
            int num = i;
            uIPopups[num].gameObject.SetActive(true);
            invisibleTarget[i].DOAnchorPosX(60f, minimizeTime).OnComplete(() => uIPopups[num].enabled = true);
            invisibleCanvasGroup[i].DOFade(1f, minimizeTime);
            
        }
        isMinimize = false;
    }

    public void Minimize()
    {
        image.transform.DOScaleY(-1f, minimizeTime / 2).SetDelay(minimizeTime / 2);

        for (int i = 0; i < invisibleTarget.Length; ++i) {
            int num = i;
            uIPopups[num].enabled = false;
            invisibleTarget[i].DOAnchorPosX(100f, minimizeTime).OnComplete(() => uIPopups[num].gameObject.SetActive(false));
            invisibleCanvasGroup[i].DOFade(0f, minimizeTime);
        }
        isMinimize = true;
    }
}