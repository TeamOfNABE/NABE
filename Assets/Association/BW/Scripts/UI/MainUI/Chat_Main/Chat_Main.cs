using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Chat_Main : MainPanel
{
    [field : SerializeField] public UIItem chat { get; private set; }
    [field : SerializeField] public SmallChat[] minimizeChat { get; private set; }
}