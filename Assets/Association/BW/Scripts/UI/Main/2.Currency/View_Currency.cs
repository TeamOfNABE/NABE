using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class View_Currency : MainPanel
{
    [field : Header("=== Gold ===")]
    [field : SerializeField] public TMP_Text goldText { get; private set; }

    [field : Header("=== Diamond ===")]
    [field : SerializeField] public TMP_Text diamondText { get; private set; }
}