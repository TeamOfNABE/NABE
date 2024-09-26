using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    public static MainCanvas instance;
    [ReadOnly] public RectTransform rect;

    public Profile_Main profile_Main;
    public Currency_Main currency_Main;
    public RoundInfo_Main roundInfo_Main;

    private void Awake()
    {
        instance = this;

        rect = GetComponent<RectTransform>();
    }
}
