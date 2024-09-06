using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCanvas : MonoBehaviour
{
    public static SceneCanvas instance ;
    public RectTransform rect;

    private void Awake()
    {
        instance = this;

        rect = GetComponent<RectTransform>();
    }
}
