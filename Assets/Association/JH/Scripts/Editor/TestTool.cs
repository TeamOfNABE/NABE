using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EventScenarioHandler))]
public class TestTool : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EventScenarioHandler itemtrigger = (EventScenarioHandler)target;

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        if (GUILayout.Button("Execute", GUILayout.Width(100), GUILayout.Height(20)))
        {
            itemtrigger.ExecuteNextEvent();
        }
        GUILayout.FlexibleSpace();  // 고정된 여백을 넣습니다.
        EditorGUILayout.EndHorizontal();  // 가로 생성 끝
    }
}
