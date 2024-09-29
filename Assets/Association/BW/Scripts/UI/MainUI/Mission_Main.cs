using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mission_Main : MainPanel
{
    [field : SerializeField] public UIItem mission { get; private set; }
    [field : SerializeField] public TMP_Text questText { get; private set; }
    [field : SerializeField] public TMP_Text progressText { get; private set; }
    [field : SerializeField] public TMP_Text rewardText { get; private set; }
}
