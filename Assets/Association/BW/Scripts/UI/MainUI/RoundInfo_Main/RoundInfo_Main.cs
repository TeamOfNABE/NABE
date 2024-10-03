using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundInfo_Main : MainPanel
{
    [field : SerializeField] public UIItem accelButton { get; private set; }
    [field : SerializeField] public TMP_Text roundText { get; private set; }
    [field : SerializeField] public RoundSlider roundSlider { get; private set; }
    [field : SerializeField] public UIItem bossButton { get; private set; }
    [field : SerializeField] public RoundTimer roundTimer { get; private set; }

    // RoundInfo 데이터 등록 필요

    // RoundInfo 추가 시 이벤트로 등록 수정 필요
    public void Round(int round) => roundSlider.SetRound(round);

    // RoundInfo 추가 시 이벤트로 등록 수정 필요
    public void Timer(float time) => roundTimer.SetTimer(time);

#if UNITY_EDITOR
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Keypad1)) {
            Round(0);
            Timer(70f);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2)) {
            Round(1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3)) {
            Round(2);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4)) {
            Round(3);
        }
        if (Input.GetKeyDown(KeyCode.Keypad5)) {
            Round(4);
        }
    }
#endif
}