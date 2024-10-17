using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View_Equipment : MainPanel
{   
    [field : Header("=== Equipment ===")]
    [field : SerializeField] public UIItem hat { get; private set; } // 투구
    [field : SerializeField] public UIItem top { get; private set; } // 상의
    [field : SerializeField] public UIItem belt { get; private set; } // 벨트
    [field : SerializeField] public UIItem cape { get; private set; } // 망토
    [field : SerializeField] public UIItem weapon { get; private set; } // 무기

    [field : SerializeField] public UIItem decoration { get; private set; } // 얼굴장식
    [field : SerializeField] public UIItem bottom { get; private set; } // 하의
    [field : SerializeField] public UIItem ring { get; private set; } // 반지
    [field : SerializeField] public UIItem gloves { get; private set; } // 장갑
    [field : SerializeField] public UIItem shell { get; private set; } // 등껍질
}