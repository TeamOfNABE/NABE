using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gacha_Main : MonoBehaviour
{
    [field : SerializeField] public UIItem gacha { get; private set; }
    [field : SerializeField] public UIItem level { get; private set; }
    [field : SerializeField] public TMP_Text levelText { get; private set; }
    [field : SerializeField] public TMP_Text countText { get; private set; }
    [field : SerializeField] public UIItem auto { get; private set; }
}
