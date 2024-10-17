using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View_Option : MainPanel
{
    [field : Header("=== Front ===")]
    [field : SerializeField] public UIItem snail { get; private set; }
    [field : SerializeField] public UIItem inventory { get; private set; }

    [field : Header("=== Back ===")]
    [field : SerializeField] public UIItem promotion { get; private set; }
    [field : SerializeField] public UIItem stat { get; private set; }
    [field : SerializeField] public UIItem preset { get; private set; }

    [field : Header("=== Minimize ===")]
    [field : SerializeField] public UIItem optionMinimize { get; private set; }
}