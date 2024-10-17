using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class View_Gacha : MonoBehaviour
{
    [field : Header("=== Gacha ===")]
    [field : SerializeField] public UIItem gacha { get; private set; }
    [field : SerializeField] public UIItem gachaLevelButton { get; private set; }
    [field : SerializeField] public TMP_Text gachaLevelText { get; private set; }
    [field : SerializeField] public TMP_Text countText { get; private set; }

    [field : Header("=== Auto  ===")]
    [field : SerializeField] public UIItem auto { get; private set; }
}