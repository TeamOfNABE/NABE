using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopupReturn : UIButton
{
    public override void OnClick(PointerEventData eventData)
    {
        Popup popup = this.GetComponentInParent<Popup>();
        PopupManager.instance.Close(popup);
    }
}