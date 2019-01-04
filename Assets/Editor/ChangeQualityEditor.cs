using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

#if UNITY_EDITOR
public class ChangeQualityEditor : Editor {

	// [MenuItem("Quality/SD")]
	// static void SD() {
	// 	ChangeQualityOnAllScenes("SD");
	// }

	// [MenuItem("Quality/HD")]
	// static void HD()
	// {
	// 	ChangeQualityOnAllScenes("HD");
	// }

	// static void ChangeQualityOnAllScenes(string suffix)
	// {
	// 	if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
	// 		return;

	// 	var currentScene = EditorSceneManager.GetActiveScene();

	// 	foreach (var scene in EditorBuildSettings.scenes)
	// 	{
	// 		EditorSceneManager.OpenScene (scene.path);
	// 		ChangeQuality.SetQuality(suffix);
	// 		EditorSceneManager.SaveScene(scene);
	// 	}

	// 	EditorApplication.OpenScene(currentScene);
	// }
}

#endif