using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReturnPopup : UIButtonItem
{
    private bool isClicked = false;

    public override void OnClick(PointerEventData eventData)
    {
        if (isClicked) return;

        Dimmed dimmed = this.GetComponentInParent<Dimmed>();
        Popup popup = this.GetComponentInParent<Popup>();
        if (dimmed != null) { popup.ClosePopup(() => Destroy(dimmed.gameObject)); }
        else { popup.ClosePopup(() => Destroy(popup.gameObject)); }
    }
}
