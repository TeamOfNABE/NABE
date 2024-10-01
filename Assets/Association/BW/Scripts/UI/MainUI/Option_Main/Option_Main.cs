using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option_Main : MainPanel
{
    [field : SerializeField] public UIItem snail { get; private set; }
    [field : SerializeField] public UIItem inventory { get; private set; }
    [field : SerializeField] public UIItem promotion { get; private set; }
    [field : SerializeField] public UIItem stat { get; private set; }
    [field : SerializeField] public UIItem preset { get; private set; }
    [field : SerializeField] public UIItem minimize { get; private set; }
}