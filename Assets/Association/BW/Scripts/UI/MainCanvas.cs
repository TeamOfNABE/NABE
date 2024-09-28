using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    public static MainCanvas instance;

    public Profile_Main profile_Main;
    public Currency_Main currency_Main;
    public RoundInfo_Main roundInfo_Main;
    public Quick_Main quick_Main;
    public Skill_Main skill_Main;
    public Equipment_Main equipment_Main;

    private void Awake()
    {
        instance = this;
    }
}