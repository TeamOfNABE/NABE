using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingView : MonoBehaviour
{
    [field : SerializeField] public TMP_Text titleText { get; private set; }
    [field : SerializeField] public UIItem cancelButton { get; private set; }
    [field : SerializeField] public UIItem okButton { get; private set; }
}