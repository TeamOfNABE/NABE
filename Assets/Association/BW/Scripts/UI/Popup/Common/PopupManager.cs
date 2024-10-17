using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class PopupManager : MonoSingleton<PopupManager>
{
    [SerializeField, ReadOnly(true)] private Canvas popupCanvas;
    [SerializeField, ReadOnly] private string popupResourcesPath = "Prefabs/UI/Popup/";
    [SerializeField, ReadOnly] private SerializedDictionary<string, Popup> popupDictionary = new SerializedDictionary<string, Popup>();

    /// <summary>
    /// 알림 팝업 (크기 가변)
    /// </summary>
    public VariablePopup Popup(string msgText)
    {
        return Popup("", msgText, null, null, "", "");
    }
    public VariablePopup Popup(string titleText, string msgText)
    {
        return Popup(titleText, msgText, null, null, "", "");
    }
    public VariablePopup Popup(string msgText, Action okAction)
    {
        return Popup("", msgText, okAction, null, "", "");
    }
    public VariablePopup Popup(string titleText, string msgText, Action okAction)
    {
        return Popup(titleText, msgText, okAction, null, "", "");
    }
    public VariablePopup Popup(string titleText, string msgText, Action okAction, string okText)
    {
        return Popup(titleText, msgText, okAction, null, okText, "");
    }
    public VariablePopup Popup(string titleText, string msgText, Action okAction, Action calnelAction, string okText, string cancelText)
    {
        var variablePopup = Open<VariablePopup>();
        okAction += () => Close(variablePopup);
        calnelAction += () => Close(variablePopup);
        variablePopup.Setting(titleText, msgText, okAction, calnelAction, okText, cancelText);
        return variablePopup;
    }

    /// <summary>
    /// ex) PopupManager.instance.Open<Popup>();
    /// 팝업 클래스로 호출 시
    /// </summary>
    public T Open<T>() where T : Popup
    {
        string key = typeof(T).ToString();

        if (popupDictionary.TryGetValue(key, out Popup value)) return (T)value;

        value = Instantiate(Resources.Load<Popup>(popupResourcesPath + key), popupCanvas.transform, false);

        popupDictionary.Add(key, value);

        return (T)value;
    }

    /// <summary>
    /// ex) PopupManager.instance.Open(Popup);
    /// 팝업  호출 시
    /// </summary>
    public T Open<T>(T popup) where T : Popup
    {
        if (popup == null) return null;

        string key = popup.GetType().ToString();

        if (popupDictionary.TryGetValue(key, out Popup value)) return (T)value;

        value = Instantiate(Resources.Load<Popup>(popupResourcesPath + key), popupCanvas.transform, false);

        popupDictionary.Add(key, value);

        return (T)value;
    }

    /// <summary>
    /// ex) PopupManager.instance.Close<Popup>();
    /// 팝업 클래스로 호출 시
    /// </summary>
    public void Close<T>() where T : Popup
    {
        string key = typeof(T).ToString();

        if (!popupDictionary.TryGetValue(key, out Popup value)) return;

        popupDictionary.Remove(key);

        value.ClosePopup();
    }

    /// <summary>
    /// ex) PopupManager.instance.Close(Popup);
    /// 팝업 오브젝트로 호출 시
    /// </summary>
    public void Close<T>(T popup) where T : Popup
    {
        string key = popup.GetType().ToString();

        if (!popupDictionary.TryGetValue(key, out Popup value)) return;

        popupDictionary.Remove(key);

        value.ClosePopup();
    }
}