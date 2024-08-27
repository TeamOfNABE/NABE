using System.IO;
using UnityEditor;
using System.Collections.Generic;

public class Editor_PlaySceneCreator : EditorWindow
{
    [MenuItem("Tools/Create Play Scene File")]
    public static void CreatePlayScene()
    {
        EditorBuildSettingsScene[] sceneList = EditorBuildSettings.scenes;

        if (sceneList.Length == 0) return;

        string playScenePath = "Assets/Association/BW/Scripts/Editor/";
        string playSceneName = "Editor_PlayScene.cs";

        if (Directory.Exists(playScenePath) == false) {
            Directory.CreateDirectory(playScenePath);
        }

        List<string> sceneNameList = new List<string>();
        foreach (var scene in sceneList) {
            string[] paths = scene.path.Split('/');
            sceneNameList.Add(paths[paths.Length - 1].Split('.')[0]);
        }

        StreamWriter sw = new StreamWriter(playScenePath + playSceneName);

        sw.WriteLine("// This enum is auto created by Editor_PlaySceneCreator.cs");
        sw.WriteLine("using UnityEditor;");
        sw.WriteLine("using UnityEditor.SceneManagement;");
        sw.WriteLine();
        sw.WriteLine("public class Editor_PlayScene : EditorWindow");
        sw.WriteLine('{');

        for (int i = 0; i < sceneNameList.Count; ++i) {
            sw.WriteLine($"\t[MenuItem(\"Editor/PlayScene/{i}. {sceneNameList[i]}\")]");
            sw.WriteLine($"\tstatic void Scene_Play_{i}() => ScenePlay({i});");
            sw.WriteLine();
        }

        sw.WriteLine("\tpublic static void ScenePlay(int SceneIndex)");
        sw.WriteLine("\t{");
        sw.WriteLine("\t\tvar pathOfFirstScene = EditorBuildSettings.scenes[SceneIndex].path;");
        sw.WriteLine("\t\tvar sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(pathOfFirstScene);");
        sw.WriteLine();
        sw.WriteLine("\t\tif (sceneAsset != null) {");
        sw.WriteLine("\t\t\tEditorSceneManager.playModeStartScene = sceneAsset;");
        sw.WriteLine("\t\t\tEditorApplication.EnterPlaymode();");
        sw.WriteLine("\t\t\tEditorApplication.quitting += Reset;");
        sw.WriteLine("\t\t}");
        sw.WriteLine("\t}");
        sw.WriteLine();
        sw.WriteLine("\t[InitializeOnEnterPlayMode]");
        sw.WriteLine("\tprivate static void OnEnterPlayMode(EnterPlayModeOptions option)");
        sw.WriteLine("\t{");
        sw.WriteLine("\t\tEditorApplication.update += Reset;");
        sw.WriteLine("\t}");
        sw.WriteLine();
        sw.WriteLine("\t private static void Reset()");
        sw.WriteLine("\t{");
        sw.WriteLine("\t\tEditorSceneManager.playModeStartScene = null;");
        sw.WriteLine("\t\tEditorApplication.update -= Reset;");
        sw.WriteLine("\t}");
        sw.WriteLine('}');
        sw.Close();

        AssetDatabase.Refresh();
        SceneView.RepaintAll();
        UnityEngine.Debug.Log("Successfully created Editor_PlayScene.cs file.");
    }

    [InitializeOnLoadMethod]
    public static void RegisterSceneListChangedCallback()
    {
        EditorBuildSettings.sceneListChanged -= CreatePlayScene;
        EditorBuildSettings.sceneListChanged += CreatePlayScene;
    }
}