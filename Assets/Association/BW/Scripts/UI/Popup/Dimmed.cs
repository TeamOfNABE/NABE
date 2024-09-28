using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dimmed : UIButton
{
    private bool isClicked = false;

    public override void OnClick(PointerEventData eventData)
    {
        // Dimmed 앞쪽 UI제외 (현재 컨텐츠 제외)
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        if (results[0].gameObject != this.gameObject) return;

        // 첫 클릭 시만 Close 예외 처리
        if (isClicked) return;

        Popup popup = this.GetComponentInChildren<Popup>();
        popup.ClosePopup(() => Destroy(this.gameObject));
    }
}