using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PopupType
{
    Null,
    VariablePopup, // 기본 팝업 (제목, 내용, 취소, 확인)
    QuickPopup, // 프로필 좌측 퀵 팝업
    ProfilePopup, // 프로필 팝업
    SettingPopup, // 설정창 (사운드, 등등)
    FadePopup, // Fade In, Out
    TabPopup,
}

public class PopupManager : MonoSingleton<PopupManager>
{
    [SerializeField, ReadOnly(true)] private Canvas popupCanvas;
    [SerializeField, ReadOnly] private string popupResourcesPath = "Prefabs/UI/Popup/";
    [SerializeField, ReadOnly] private List<Popup> popupList = new List<Popup>();

    public void Open(PopupType popupType)
    {
        if (popupType == PopupType.Null) return;

        var popup = Instantiate(Resources.Load<Popup>(popupResourcesPath + popupType), popupCanvas.transform, false);
        popupList.Add(popup);
    }

    public void Close(Popup popup)
    {
        popupList.Remove(popup);

        popup.ClosePopup();
    }
}