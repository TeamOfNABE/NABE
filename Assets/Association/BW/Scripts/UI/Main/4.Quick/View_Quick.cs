using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View_Quick : MainPanel
{
    [field : Header("=== Left Quick Panel ===")]
    [field : SerializeField] public UIItem adventureButton { get; private set; }
    [field : SerializeField] public UIItem passButton { get; private set; }

    [field : Header("=== Right Quick Panel ===")] 
    [field : SerializeField] public UIItem invisibleButton { get; private set; }
    [field : SerializeField] public UIItem[] quickButton { get; private set; }
    [field : SerializeField] public UIItem quickMinimize { get; private set; }
}