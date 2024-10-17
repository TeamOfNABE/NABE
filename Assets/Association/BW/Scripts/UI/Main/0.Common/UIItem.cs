using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UIItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerClickHandler
{
    protected Action action;
    [ReadOnly] public RectTransform rect;
    public void OnPointerEnter(PointerEventData eventData) => OnEnter(eventData);
    public void OnPointerExit(PointerEventData eventData) => OnExit(eventData);
    public void OnPointerDown(PointerEventData eventData) { /* (첫 클릭 시 UI 확인) Dimmed 제외 처리 필요 */}
    public void OnPointerClick(PointerEventData eventData) { action?.Invoke(); OnClick(eventData); }
    
    public abstract void OnEnter(PointerEventData eventData);
    public abstract void OnExit(PointerEventData eventData);
    public abstract void OnClick(PointerEventData eventData);

    public virtual void AddEvent(Action action)
    {
        this.action += action;
    }

    protected virtual void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
}