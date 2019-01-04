using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadLogo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("LoadL", 3f);
	}
	
	// Update is called once per frame
	void LoadL () {
		SceneManager.LoadScene("PreloadLogo");
	}
}
