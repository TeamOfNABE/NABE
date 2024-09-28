using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundInfo_Main : MonoBehaviour
{
    [field : SerializeField] public UIItem accelButton { get; private set; }
    [field : SerializeField] public TMP_Text roundText { get; private set; }
    [field : SerializeField] public Slider roundSlider { get; private set; }
    [field : SerializeField] public Transform[] roundPoints { get; private set; }
    [field : SerializeField] public Slider timerSlider { get; private set; }
    [field : SerializeField] public TMP_Text timerText { get; private set; }
    [field : SerializeField] public UIItem bossButton { get; private set; }
}
