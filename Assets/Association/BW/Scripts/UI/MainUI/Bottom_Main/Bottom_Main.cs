using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom_Main : MainPanel
{
    [field : SerializeField] public UIItem growth { get; private set; }
    [field : SerializeField] public UIItem dungeon { get; private set; }
    [field : SerializeField] public UIItem duel { get; private set; }
    [field : SerializeField] public UIItem town { get; private set; }
    [field : SerializeField] public UIItem greenhouse { get; private set; }
    [field : SerializeField] public UIItem shop { get; private set; }
}