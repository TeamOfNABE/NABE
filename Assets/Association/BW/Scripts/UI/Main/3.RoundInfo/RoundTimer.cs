using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RoundTimer : MonoBehaviour
{
    [field : SerializeField] public Slider timerSlider { get; private set; }
    [field : SerializeField] public TMP_Text timerText { get; private set; }

    private float currentTime = 0f;
    private int min;
    private int sec;
    private Coroutine timerCoroutine;

    public void SetTimer(float time, Action callBack = null)
    {
        if (timerCoroutine != null) StopCoroutine(timerCoroutine);
        timerCoroutine = StartCoroutine(TimerCoroutine(time, callBack));
    }

    private IEnumerator TimerCoroutine(float time, Action callBack)
    {
        currentTime = time;

        while (currentTime >= 0) {
            currentTime -= Time.deltaTime;

            min = (int)currentTime / 60;
            sec = ((int)currentTime - min * 60) % 60;

            timerSlider.value = Mathf.InverseLerp(0f, time, currentTime);
            timerText.text = min > 0 ? string.Format("{0:D2} : {1:D2}", min, (int)sec + 1) : (sec + 1).ToString();

            yield return new WaitForEndOfFrame();
        }
        timerSlider.value = 0f;
        timerText.text = "0";
        callBack?.Invoke();
    }
}