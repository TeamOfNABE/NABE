using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonCall : MonoBehaviour
{
    private void Awake()
    {
        SoundManager.instance.Call();
        UIManager.instance.Call();
        //OptionPopup.instance.Call();
        //FadePopup.instance.Call();
        Destroy(this.gameObject);
    }
}