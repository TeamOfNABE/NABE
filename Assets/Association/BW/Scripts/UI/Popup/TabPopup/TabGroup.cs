using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    [Serializable]
    public struct TabColor
    {
        public Color idle;
        public Color hover;
        public Color active;
    }
    
    [SerializeField] private TabColor tabColor;
    [SerializeField] private RectTransform tabParent;
    [SerializeField] private RectTransform tabContentParent;
    [SerializeField] private List<UITab> tabList = new List<UITab>();        
    [SerializeField] private List<TabContent> tabContentList = new List<TabContent>();
    [SerializeField, ReadOnly] private UITab selectedTab = null;
    
    private void Awake()
    {
        foreach (RectTransform tab in tabParent) {
            Subscribe_Tab(tab);
        }
        foreach (RectTransform content in tabContentParent) {
            Subscribe_Content(content);
        }
    }

    private void OnEnable()
    {
        foreach (var tab in tabList) {
            int index = tab.transform.GetSiblingIndex();
            if (index == 0) {
                selectedTab = tab;
                tab.GetComponent<Image>().color = tabColor.active;
            }
            else {
                tab.GetComponent<Image>().color = tabColor.idle;
            }
        }

        foreach (var content in tabContentList) {
            int index = content.transform.GetSiblingIndex();
            if (index == 0) {
                content.gameObject.SetActive(true);
            }
            else {
                content.gameObject.SetActive(false);
            }
        }
    }

    public void Subscribe_Tab(RectTransform tab)
    {
        var uiTab = tab.GetComponent<UITab>();
        uiTab.Subscribe(this);
        tabList.Add(uiTab);
    }

    public void Subscribe_Content(RectTransform content)
    {
        var tabContent = content.GetComponent<TabContent>();
        tabContent.Subscribe(this);
        tabContentList.Add(tabContent);
    }

    /// <summary>
    /// Pointer Enter
    /// </summary>
    public void OnTabEnter(UITab tab)
    {
        ResetTabs();
        if (selectedTab == null || tab != selectedTab) {
            tab.image.color = tabColor.hover;
        }
    }

    /// <summary>
    /// Pointer Exit
    /// </summary>
    public void OnTabExit(UITab tab)
    {
        ResetTabs();
    }

    /// <summary>
    /// Pointer Click
    /// </summary>
    public void OnTabSelected(UITab tab)
    {
        if (selectedTab != null) {
            selectedTab.Deselect();
        }
        selectedTab = tab;
        selectedTab.Select();
        
        ResetTabs();
        tab.image.color = tabColor.active;

        int index = tab.transform.GetSiblingIndex();
        for (int i = 0; i < tabContentList.Count; ++i) {
            if (index == tabContentList[i].transform.GetSiblingIndex()) {
                tabContentList[i].gameObject.SetActive(true);
            }
            else {
                tabContentList[i].gameObject.SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach (UITab tab in tabList) {
            if (selectedTab != null && tab == selectedTab) continue;
            tab.image.color = tabColor.idle;
        }
    }

    /// <summary>
    /// Pointer Selected Event
    /// </summary>
    public void Select(UITab button)
    {

    }

    /// <summary>
    /// Pointer UnSelected Event
    /// </summary>
    public void Deselect(UITab button)
    {

    }
}
