using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class View_Mission : MainPanel
{
    [field : Header("=== Mission ===")]
    [field : SerializeField] public UIItem mission { get; private set; }
    [field : SerializeField] public TMP_Text questText { get; private set; }
    [field : SerializeField] public TMP_Text progressText { get; private set; }
    [field : SerializeField] public TMP_Text rewardText { get; private set; }
}