using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopup : Popup
{
    [SerializeField] private SettingView settingView;
    [SerializeField] private SoundVolumeControl soundVolumeControl;

    public override void OK()
    {
        soundVolumeControl.SaveVolume();
    }
}