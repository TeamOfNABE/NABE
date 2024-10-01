using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Main : MainPanel
{
    [field : SerializeField] public UIItem auto { get; private set; }
    [field : SerializeField] public UIItem[] skills { get; private set; }
    [field : SerializeField] public UIItem minimize { get; private set; }
}