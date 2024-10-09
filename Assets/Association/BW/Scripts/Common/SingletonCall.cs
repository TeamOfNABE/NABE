using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonCall : MonoBehaviour
{
    private void Awake()
    {
        SoundManager.instance.Call();
        PopupManager.instance.Call();
    }

    private void Start()
    {
        Destroy(this.gameObject);
    }
}