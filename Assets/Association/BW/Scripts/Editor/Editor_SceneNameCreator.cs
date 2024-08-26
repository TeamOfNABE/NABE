
using System.Collections.Generic;
using System.IO;
using UnityEditor;

public class Editor_SceneNameCreator
{
    [MenuItem("Tools/Create Scene Enum file")]
    public static void CreateEnum()
    {
        EditorBuildSettingsScene[] sceneList = EditorBuildSettings.scenes;

        if (sceneList.Length == 0) return;

        string sceneNamePath = "Assets/Association/BW/Scripts/SceneLoad/";
        string sceneNameFile = "SceneLoadManager_SceneName.cs";

        if (Directory.Exists(sceneNamePath) == false) {
            Directory.CreateDirectory(sceneNamePath);
        }

        List<string> sceneNameList = new List<string>();
        foreach (var scene in sceneList) {
            string[] paths = scene.path.Split('/');
            sceneNameList.Add(paths[paths.Length - 1].Split('.')[0]);
        }

        StreamWriter sw = new StreamWriter(sceneNamePath + sceneNameFile);

        sw.WriteLine("// This enum is auto created by Editor_SceneNameCreator.cs");
        sw.WriteLine();
        sw.WriteLine("public enum SceneName");
        sw.WriteLine('{');
        foreach (var sceneName in sceneNameList) {
            sw.WriteLine($"\t{sceneName},");
        }
        sw.WriteLine($"\tNull,");
        sw.WriteLine("}");
        sw.Close();
        UnityEngine.Debug.Log("Successfully created scene enum file.");
    }

    [InitializeOnLoadMethod]
    public static void RegisterSceneListChangedCallback()
    {
        EditorBuildSettings.sceneListChanged -= CreateEnum;
        EditorBuildSettings.sceneListChanged += CreateEnum;
    }
}