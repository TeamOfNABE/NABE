using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RoundSlider : MonoBehaviour
{
    [field : SerializeField] public Slider roundSlider { get; private set; }
    [field : SerializeField] public Transform[] roundPoints { get; private set; }
    [SerializeField] private float changePointOffset = .1f;

    private void Awake()
    {
        roundSlider.onValueChanged.AddListener((value) => SetSlider(value));
        roundSlider.value = 0f;
    }

    public void SetRound(int round)
    {
        roundSlider.DOKill();
        roundSlider.DOValue(round, .5f);
    }

    private void SetSlider(float round)
    {
        for (int i = 0; i < roundPoints.Length; ++i) {
            roundPoints[i].GetChild(0).gameObject.SetActive(false);
            roundPoints[i].GetChild(1).gameObject.SetActive(false);

            if (i >= round - changePointOffset && i < round + changePointOffset) {
                roundPoints[i].GetChild(0).gameObject.SetActive(true);
            }
            else if (i < round + changePointOffset){
                roundPoints[i].GetChild(1).gameObject.SetActive(true);
            }
        }
    }
}