using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SmallChat : MonoBehaviour
{
    [field : SerializeField] public TMP_Text serverText { get; private set; }
    [field : SerializeField] public TMP_Text titleText { get; private set; }
    [field : SerializeField] public TMP_Text messageText { get; private set; }
}
