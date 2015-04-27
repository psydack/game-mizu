using UnityEngine;
using UnityEditor;

public class ChangeQualityEditor : Editor {

	[MenuItem("Quality/SD")]
	static void SD() {
		ChangeQualityOnAllScenes("SD");
	}

	[MenuItem("Quality/HD")]
	static void HD()
	{
		ChangeQualityOnAllScenes("HD");
	}

	static void ChangeQualityOnAllScenes(string suffix)
	{
		if (!EditorApplication.SaveCurrentSceneIfUserWantsTo())
			return;

		var currentScene = EditorApplication.currentScene;

		foreach (var scene in EditorBuildSettings.scenes)
		{
			EditorApplication.OpenScene (scene.path);
			ChangeQuality.SetQuality(suffix);
			EditorApplication.SaveScene();
		}

		EditorApplication.OpenScene(currentScene);
	}
}
