using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System.Threading;
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

    private IEnumerator TimerCoroutine(float time, Action callback)
    {
        this.currentTime = time;

        while (this.currentTime >= 0) {
            currentTime -= Time.deltaTime;

            min = (int)this.currentTime / 60;
            sec = ((int)this.currentTime - min * 60) % 60;

            timerSlider.value = Mathf.InverseLerp(0f, time, this.currentTime);
            timerText.text = string.Format("{0:D2} : {1:D2}", min, (int)sec + 1);

            yield return new WaitForEndOfFrame();
        }
        timerSlider.value = 0f;
        timerText.text = string.Format("{0:D2} : {1:D2}", 0, 0);
        callback?.Invoke();
    }
}