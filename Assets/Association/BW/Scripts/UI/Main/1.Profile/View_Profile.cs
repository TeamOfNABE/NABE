using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class View_Profile : MainPanel
{
    [field : Header("=== Profile ===")]
    [field : SerializeField] public Image profileImg { get; private set; }

    [field : Header("=== Level ===")]
    [field : SerializeField] public TMP_Text levelText { get; private set; }
    
    [field : Header("=== NickName ===")]
    [field : SerializeField] public TMP_Text nickNameText { get; private set; }

    [field : Header("=== Exp ===")]
    [field : SerializeField] public Image expImg { get; private set; }
    [field : SerializeField] public TMP_Text expText { get; private set; }
}