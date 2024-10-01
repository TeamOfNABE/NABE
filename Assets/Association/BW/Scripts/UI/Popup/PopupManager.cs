using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

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
    [SerializeField, ReadOnly] private List<PopupType> popupTypeList = new List<PopupType>();

    public void Open(PopupType popupType)
    {
        if (popupType == PopupType.Null) return;
        if (popupTypeList.Contains(popupType)) return;

        var popup = Instantiate(Resources.Load<Popup>(popupResourcesPath + popupType), popupCanvas.transform, false);
        popup.popupType = popupType;

        popupTypeList.Add(popupType);
    }

    public void Close(Popup popup)
    {
        popupTypeList.Remove(popup.popupType);

        popup.ClosePopup();
    }

    public void OK(Popup popup)
    {
        popup.OK();

        Close(popup);
    }
}