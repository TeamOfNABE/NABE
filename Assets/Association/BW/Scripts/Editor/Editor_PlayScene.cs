// This enum is auto created by Editor_PlaySceneCreator.cs
using UnityEditor;
using UnityEditor.SceneManagement;

public class Editor_PlayScene : EditorWindow
{
	[MenuItem("Editor/PlayScene/0. Login")]
	static void Scene_Play_0() => ScenePlay(0);

	[MenuItem("Editor/PlayScene/1. Loading")]
	static void Scene_Play_1() => ScenePlay(1);

	[MenuItem("Editor/PlayScene/2. Main")]
	static void Scene_Play_2() => ScenePlay(2);

	public static void ScenePlay(int SceneIndex)
	{
		var pathOfFirstScene = EditorBuildSettings.scenes[SceneIndex].path;
		var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(pathOfFirstScene);

		if (sceneAsset != null) {
			EditorSceneManager.playModeStartScene = sceneAsset;
			EditorApplication.EnterPlaymode();
			EditorApplication.quitting += Reset;
		}
	}

	[InitializeOnEnterPlayMode]
	private static void OnEnterPlayMode(EnterPlayModeOptions option)
	{
		EditorApplication.update += Reset;
	}

	 private static void Reset()
	{
		EditorSceneManager.playModeStartScene = null;
		EditorApplication.update -= Reset;
	}
}
