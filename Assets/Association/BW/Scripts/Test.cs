using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(Fade_Out), 3f);
        Invoke(nameof(Fade_In), 5f);
    }

    public void Fade_Out()
    {
        FadePopup.instance.FadeOut(/*() => SceneLoadManager.SceneLoad(SceneName.Main)*/);
    }

    public void Fade_In()
    {
        FadePopup.instance.FadeIn();
    }
}
