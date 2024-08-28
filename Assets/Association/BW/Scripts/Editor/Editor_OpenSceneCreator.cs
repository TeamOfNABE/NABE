using System.IO;
using UnityEditor;
using System.Collections.Generic;
public class Editor_OpenSceneCreator : EditorWindow
{
    [MenuItem("Tools/Create Open Scene File")]
    public static void CreateOpenScene()
    {
        EditorBuildSettingsScene[] sceneList = EditorBuildSettings.scenes;

        if (sceneList.Length == 0) return;

        string openScenePath = "Assets/Association/BW/Scripts/Editor/";
        string openSceneName = "Editor_OpenScene.cs";

        if (Directory.Exists(openScenePath) == false) {
            Directory.CreateDirectory(openScenePath);
        }

        List<string> sceneNameList = new List<string>();
        foreach (var scene in sceneList) {
            string[] paths = scene.path.Split('/');
            sceneNameList.Add(paths[paths.Length - 1].Split('.')[0]);
        }

        StreamWriter sw = new StreamWriter(openScenePath + openSceneName);

        sw.WriteLine("// This enum is auto created by Editor_OpenSceneCreator.cs");
        sw.WriteLine("using UnityEditor;");
        sw.WriteLine("using UnityEditor.SceneManagement;");
        sw.WriteLine();
        sw.WriteLine("public class Editor_OpenScene : EditorWindow");
        sw.WriteLine('{');

        for (int i = 0; i < sceneNameList.Count; ++i) {
            sw.WriteLine($"\t[MenuItem(\"Editor/OpenScene/{i}. {sceneNameList[i]}\")]");
            sw.WriteLine($"\tstatic void Scene_{i}() => SceneOpen({i});");
            sw.WriteLine();
        }

        sw.WriteLine("\tstatic public void SceneOpen(int SceneIndex)");
        sw.WriteLine("\t{");
        sw.WriteLine("\t\tvar pathOfFirstScene = EditorBuildSettings.scenes[SceneIndex].path;");
        sw.WriteLine("\t\tvar sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(pathOfFirstScene);");
        sw.WriteLine("\t\tvar sceneName = sceneAsset.ToString().Split(' ');");
        sw.WriteLine();
        sw.WriteLine("\t\tif (sceneAsset != null) {");
        sw.WriteLine("\t\t\tEditorSceneManager.OpenScene(\"Assets/Scenes/\" + sceneName[0] + \".unity\");");
        sw.WriteLine("\t\t}");
        sw.WriteLine("\t}");
        sw.WriteLine("}");
        sw.Close();

        AssetDatabase.Refresh();
        SceneView.RepaintAll();
        UnityEngine.Debug.Log("Successfully created Editor_OpenScene.cs file.");
    }

    [InitializeOnLoadMethod]
    public static void RegisterSceneListChangedCallback()
    {
        EditorBuildSettings.sceneListChanged -= CreateOpenScene;
        EditorBuildSettings.sceneListChanged += CreateOpenScene;
    }
}