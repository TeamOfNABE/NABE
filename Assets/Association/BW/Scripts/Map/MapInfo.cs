using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfo : MonoBehaviour
{
    [SerializeField] private AudioClip bgmClip;
    
    private void Start()
    {
        SoundManager.instance.PlayBGM(bgmClip);
    }
}