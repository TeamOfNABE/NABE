using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_Login : MonoBehaviour
{
    public Button gotoMain;

    private void Awake()
    {
        gotoMain.onClick.AddListener(() => SceneLoadManager.SceneLoad(SceneName.Main));
    }
}
