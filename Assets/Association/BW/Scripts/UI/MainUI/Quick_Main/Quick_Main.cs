using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quick_Main : MainPanel
{
    // Left Quick Panel
    [field : SerializeField] public UIItem adventureButton { get; private set; }
    [field : SerializeField] public UIItem passButton { get; private set; }

    // Right Quick Panel
    [field : SerializeField] public UIItem checkButton { get; private set; }
    [field : SerializeField] public UIItem quick1Button { get; private set; }
    [field : SerializeField] public UIItem quick2Button { get; private set; }
    [field : SerializeField] public UIItem quick3Button { get; private set; }
    [field : SerializeField] public UIItem quick4Button { get; private set; }
    [field : SerializeField] public UIItem quick5Button { get; private set; }
    [field : SerializeField] public UIItem quick6Button { get; private set; }
    [field : SerializeField] public UIItem quick7Button { get; private set; }
    [field : SerializeField] public UIItem quick8Button { get; private set; }
    [field : SerializeField] public UIItem minimize { get; private set; }
}