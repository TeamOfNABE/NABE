using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VariablePopup : Popup
{
    [Space(10f)]
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text msgText;
    [Space(10f)]
    [SerializeField] private UIItem okButton;
    [SerializeField] private UIItem cancelButton;
    [Space(10f)]
    [SerializeField] private TMP_Text okText;
    [SerializeField] private TMP_Text cancelText;

    public void Setting(string titleText, string msgText, Action ok, Action calnel, string okText, string cancelText)
    {
        this.titleText.text = titleText;
        this.msgText.text = msgText;

        this.okButton.AddEvent(() => ok?.Invoke());
        this.cancelButton.AddEvent(() => calnel?.Invoke());

        if (okText != "") this.okText.text = okText;
        if (cancelText != "") this.cancelText.text = cancelText;
    }
}