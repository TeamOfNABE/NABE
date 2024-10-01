using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeControl : MonoBehaviour
{
    [SerializeField] private SoundVolumeView soundVolumeView;

    private void Start()
    {
        // Slider Setting (Min value shoule be '0.0001f')
        soundVolumeView.masterSlider.minValue = 0.0001f;
        soundVolumeView.musicSlider.minValue = 0.0001f;
        soundVolumeView.sfxSlider.minValue = 0.0001f;

        // Slider OnValueChanged Setting
        soundVolumeView.masterSlider.onValueChanged.AddListener((value) => SoundManager.instance.MasterVolume(value));
        soundVolumeView.musicSlider.onValueChanged.AddListener((value) => SoundManager.instance.MusicVolume(value));
        soundVolumeView.sfxSlider.onValueChanged.AddListener((value) => SoundManager.instance.SFXVolume(value));
        
        // Get Saved value
        GetVolume(out float masterVol, out float musicVol, out float sfxVol);

        // Set Slider value
        SetVolume(masterVol, musicVol, sfxVol);
    }

    private void GetVolume(out float masterVol, out float musicVol, out float sfxVol)
    {
        masterVol = PlayerPrefsData.Get<float>("MasterVol", 0.5f);
        musicVol = PlayerPrefsData.Get<float>("MusicVol", 0.5f);
        sfxVol = PlayerPrefsData.Get<float>("SFXVol", 0.5f);
    }

    private void SetVolume(float masterVol, float musicVol, float sfxVol)
    {
        SoundManager.instance.MasterVolume(masterVol);
        SoundManager.instance.MusicVolume(musicVol);
        SoundManager.instance.SFXVolume(sfxVol);

        soundVolumeView.masterSlider.value = masterVol;
        soundVolumeView.musicSlider.value = musicVol;
        soundVolumeView.sfxSlider.value = sfxVol;
    }

    public void SaveVolume()
    {
        PlayerPrefsData.Set("MasterVol", soundVolumeView.masterSlider.value);
        PlayerPrefsData.Set("MusicVol", soundVolumeView.musicSlider.value);
        PlayerPrefsData.Set("SFXVol", soundVolumeView.sfxSlider.value);
    }
}