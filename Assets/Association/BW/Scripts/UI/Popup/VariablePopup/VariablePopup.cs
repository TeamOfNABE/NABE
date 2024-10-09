using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VariablePopup : Popup
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text msgText;
    [SerializeField] private UIItem okButton;
    [SerializeField] private UIItem cancelButton;

    public void Setting(string title, string msg, Action ok, Action calnel = null)
    {
        this.titleText.text = title;
        this.msgText.text = msg;
        this.okButton.AddEvent(() => ok?.Invoke());
        this.cancelButton.AddEvent(() => calnel?.Invoke());
    }
    public override void OK()
    {
        // Setting에서 Action 동적 할당
    }
}