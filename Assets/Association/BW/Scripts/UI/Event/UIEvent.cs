using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UIEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    protected Action action;
    [ReadOnly] public RectTransform rect;
    public void OnPointerEnter(PointerEventData eventData) => OnEnter(eventData);
    public void OnPointerExit(PointerEventData eventData) => OnExit(eventData);
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