// This enum is auto created by Editor_OpenSceneCreator.cs
using UnityEditor;
using UnityEditor.SceneManagement;

public class Editor_OpenScene : EditorWindow
{
	[MenuItem("Editor/OpenScene/0. Login")]
	static void Scene_0() => SceneOpen(0);

	[MenuItem("Editor/OpenScene/1. Loading")]
	static void Scene_1() => SceneOpen(1);

	[MenuItem("Editor/OpenScene/2. Main")]
	static void Scene_2() => SceneOpen(2);

	static public void SceneOpen(int SceneIndex)
	{
		var pathOfFirstScene = EditorBuildSettings.scenes[SceneIndex].path;
		var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(pathOfFirstScene);
		var sceneName = sceneAsset.ToString().Split(' ');

		if (sceneAsset != null) {
			EditorSceneManager.OpenScene("Assets/Scenes/" + sceneName[0] + ".unity");
		}
	}
}
