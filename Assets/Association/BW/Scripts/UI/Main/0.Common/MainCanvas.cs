using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainCanvas : MonoBehaviour
{
    public static MainCanvas instance;
    public View_Main view;


    private void Awake()
    {
        instance = this;
    }
}