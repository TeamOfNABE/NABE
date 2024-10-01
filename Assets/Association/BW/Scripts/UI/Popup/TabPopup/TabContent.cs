using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabContent : MonoBehaviour
{
    public TabGroup tabGroup;
    
    public void Subscribe(TabGroup tabGroup)
    {
        this.tabGroup = tabGroup;
    }
}