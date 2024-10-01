using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UITab : UIButton
{
    public TabGroup tabGroup;
    public Image image { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        image = GetComponent<Image>();
    }

    public void Subscribe(TabGroup tabGroup)
    {
        this.tabGroup = tabGroup;
    }

    public override void OnEnter(PointerEventData eventData)
    {
        base.OnEnter(eventData);
        tabGroup.OnTabEnter(this);
    }

    public override void OnExit(PointerEventData eventData)
    {
        base.OnExit(eventData);
        tabGroup.OnTabExit(this);
    }

    public override void OnClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }

    public void Select()
    {
        tabGroup.Select(this);
    }

    public void Deselect()
    {
        tabGroup.Deselect(this);
    }
}