using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class View_Chat : MainPanel
{
    [field : Header("=== Chat ===")]
    [field : SerializeField] public UIItem chat { get; private set; }
    [field : SerializeField] public SmallChat[] smallChat { get; private set; }
}