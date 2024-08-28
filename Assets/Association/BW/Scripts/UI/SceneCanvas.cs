using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCanvas : MonoBehaviour
{
    public static SceneCanvas instance ;

    private void Awake()
    {
        instance = this;
    }
}
