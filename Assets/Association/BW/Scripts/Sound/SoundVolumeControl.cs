using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeControl : MonoBehaviour
{
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        // Slider Setting (Min value shoule be '0.0001f')
        masterSlider.minValue = 0.0001f;
        musicSlider.minValue = 0.0001f;
        sfxSlider.minValue = 0.0001f;

        // Slider OnValueChanged Setting
        masterSlider.onValueChanged.AddListener((value) => SoundManager.instance.MasterVolume(value));
        musicSlider.onValueChanged.AddListener((value) => SoundManager.instance.MusicVolume(value));
        sfxSlider.onValueChanged.AddListener((value) => SoundManager.instance.SFXVolume(value));
        
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

        masterSlider.value = masterVol;
        musicSlider.value = musicVol;
        sfxSlider.value = sfxVol;
    }

    private void SaveVolume()
    {
        PlayerPrefsData.Set("MasterVol", masterSlider.value);
        PlayerPrefsData.Set("MusicVol", musicSlider.value);
        PlayerPrefsData.Set("SFXVol", sfxSlider.value);
    }

    private void OnApplicationQuit()
    {
        SaveVolume();
    }
}