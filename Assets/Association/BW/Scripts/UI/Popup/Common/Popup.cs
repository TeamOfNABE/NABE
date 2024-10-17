using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

[RequireComponent(typeof(CanvasGroup))]
abstract public class Popup : PopupEffect
{
    [Tooltip("체크 시 배경 딤드처리(배경 클릭 Off)")] public bool isDimmed = true;
    [Tooltip("체크 시 배경 딤드처리로 Close")] public bool isDimmedClose = true;
    private string dimmedPath = "Prefabs/UI/Popup/Dimmed";

    public virtual void Awake()
    {
        SettingDimmed();
    }

    /// <summary>
    /// Setting Dimmed
    /// </summary>
    private void SettingDimmed()
    {
        Dimmed dimmed = Instantiate(Resources.Load<Dimmed>(dimmedPath), this.transform.parent, false);
        this.transform.SetParent(dimmed.transform, false);
        dimmed.name = "Dimmed_" + this.gameObject.name;
    }
}