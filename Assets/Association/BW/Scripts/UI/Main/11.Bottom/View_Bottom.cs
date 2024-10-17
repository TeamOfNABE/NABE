using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View_Bottom : MainPanel
{
    [field : Header("=== Growth ===")]
    [field : SerializeField] public UIItem growth { get; private set; }

    [field : Header("=== Dungeon ===")]
    [field : SerializeField] public UIItem dungeon { get; private set; }

    [field : Header("=== Duel ===")]
    [field : SerializeField] public UIItem duel { get; private set; }

    [field : Header("=== Town ===")]
    [field : SerializeField] public UIItem town { get; private set; }

    [field : Header("=== Greenhouse ===")]
    [field : SerializeField] public UIItem greenhouse { get; private set; }

    [field : Header("=== Shop ===")]
    [field : SerializeField] public UIItem shop { get; private set; }
}