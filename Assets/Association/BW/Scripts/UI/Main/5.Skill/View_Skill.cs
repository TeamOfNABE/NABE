using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View_Skill : MainPanel
{
    [field : Header("=== Auto ===")]
    [field : SerializeField] public UIItem autoButton { get; private set; }

    [field : Header("=== Skill ===")]
    [field : SerializeField] public UIItem[] skill { get; private set; }

    [field : Header("=== Minimize ===")]
    [field : SerializeField] public UIItem skillMinimize { get; private set; }
}