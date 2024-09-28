using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Main : MonoBehaviour
{
    [field : SerializeField] public UIItem auto { get; private set; }
    [field : SerializeField] public UIItem[] skills { get; private set; }
}
