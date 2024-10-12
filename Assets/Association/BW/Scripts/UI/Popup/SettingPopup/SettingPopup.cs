using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingPopup : Popup
{
    [field : SerializeField] public TMP_Text titleText { get; private set; }
    [field : SerializeField] public UIItem okButton { get; private set; }
    
    [SerializeField] private SoundVolumeControl soundVolumeControl;

    private void Start()
    {
        okButton.AddEvent(() => soundVolumeControl.SaveVolume());
    }
}