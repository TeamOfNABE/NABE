using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    public static MainCanvas instance;
    public RectTransform rect;

    private void Awake()
    {
        instance = this;

        rect = GetComponent<RectTransform>();
    }
}
