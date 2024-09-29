using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] 
public struct MainUI
{
    [field : SerializeField] public Profile_Main profile_Main { get; private set; }
    [field : SerializeField] public Currency_Main currency_Main { get; private set; }
    [field : SerializeField] public RoundInfo_Main roundInfo_Main { get; private set; }
    [field : SerializeField] public Quick_Main quick_Main { get; private set; }
    [field : SerializeField] public Skill_Main skill_Main { get; private set; }
    [field : SerializeField] public Equipment_Main equipment_Main { get; private set; }
    [field : SerializeField] public Option_Main option_Main { get; private set; }
    [field : SerializeField] public Chat_Main chat_Main { get; private set; }
    [field : SerializeField] public Gacha_Main gacha_Main { get; private set; }
    [field : SerializeField] public Mission_Main mission_Main { get; private set; }
    [field : SerializeField] public Bottom_Main bottom_Main { get; private set; }
}

public class MainCanvas : MonoBehaviour
{
    public static MainCanvas instance;

    public MainUI mainUI; // 중 분류 컨텐츠


    private void Awake()
    {
        instance = this;
    }
}