using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;

public class MinimizeQuick : UIButton, IMinimizeToggle
{
    public bool isMinimize { get; set; }
    public float minimizeTime { get; set; } = .5f;
    [field : SerializeField] public Image image { get; set; }
    [field : SerializeField] public RectTransform minimizetTarget { get; set; }
    
    [Space(20f)]
    private Vector2 originalSize;
    private Vector2 minimizeSize;
    private GridLayoutGroup minimizetTargetLayout;
    [SerializeField] private RectTransform[] moveTarget;

    protected override void Awake()
    {
        base.Awake();
        originalSize = minimizetTarget.rect.size;
        minimizetTargetLayout = minimizetTarget.GetComponent<GridLayoutGroup>();

        float xSize = minimizetTargetLayout.cellSize.x + minimizetTargetLayout.spacing.x * 2;
        float ySize = minimizetTargetLayout.cellSize.y * moveTarget.Count() + minimizetTargetLayout.spacing.y * (moveTarget.Count() + 1);
        minimizeSize = new Vector2(xSize, ySize);
    }

    public override void OnClick(PointerEventData eventData)
    {
        if (isMinimize) Maximize();
        else Minimize();
    }

    public void Maximize()
    {
        minimizetTarget.DOKill();

        minimizetTarget.DOSizeDelta(originalSize, minimizeTime);
        image.transform.DOScaleY(1f, minimizeTime / 2).SetDelay(minimizeTime);


        isMinimize = false;
    }

    public void Minimize()
    {
        minimizetTarget.DOKill();
        
        minimizetTarget.DOSizeDelta(minimizeSize, minimizeTime).SetEase(Ease.OutBack);
        image.transform.DOScaleY(-1f, minimizeTime / 2).SetDelay(minimizeTime / 2);

        isMinimize = true;
    }
}