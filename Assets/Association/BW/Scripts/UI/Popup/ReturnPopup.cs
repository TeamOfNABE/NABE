using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReturnPopup : UIButton
{
    private bool isClicked = false;

    public override void OnClick(PointerEventData eventData)
    {
        if (isClicked) return;

        Popup popup = this.GetComponentInParent<Popup>();
        PopupManager.instance.Close(popup);
    }
}