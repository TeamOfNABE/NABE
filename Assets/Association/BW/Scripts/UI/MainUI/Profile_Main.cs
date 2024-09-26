using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Profile_Main : MonoBehaviour
{
    [field : SerializeField] public Image profileImg { get; private set; }
    [field : SerializeField] public TMP_Text levelText { get; private set; }
    [field : SerializeField] public TMP_Text nickNameText { get; private set; }
    [field : SerializeField] public Image expImg { get; private set; }
    [field : SerializeField] public TMP_Text expText { get; private set; }
}