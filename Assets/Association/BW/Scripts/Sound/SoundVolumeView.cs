using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeView : MonoBehaviour
{
    [field : SerializeField] public Toggle masterToggle { get; private set; }
    [field : SerializeField] public Slider masterSlider  { get; private set; }

    [field : SerializeField] public Toggle bgmToggle { get; private set; }
    [field : SerializeField] public Slider bgmSlider { get; private set; }
    
    [field : SerializeField] public Toggle sfxToggle { get; private set; }
    [field : SerializeField] public Slider sfxSlider { get; private set; }

    private void Awake()
    {
        masterSlider.minValue = 0.0001f;
        bgmSlider.minValue = 0.0001f;
        sfxSlider.minValue = 0.0001f;
    }

    public void OnEnable()
    {
        SoundManager.instance.GetControl().SettingSound(AudioType.Master, masterToggle, masterSlider);
        SoundManager.instance.GetControl().SettingSound(AudioType.BGM, bgmToggle, bgmSlider);
        SoundManager.instance.GetControl().SettingSound(AudioType.SFX, sfxToggle, sfxSlider);
    }
}