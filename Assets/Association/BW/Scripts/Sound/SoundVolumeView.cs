using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeView : MonoBehaviour
{
    [field : SerializeField] public Slider masterSlider  { get; private set; }
    [field : SerializeField] public Slider musicSlider { get; private set; }
    [field : SerializeField] public Slider sfxSlider { get; private set; }
}