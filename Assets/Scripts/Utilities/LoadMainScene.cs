﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadMainScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("LoadL", 5f);
	}
	
	// Update is called once per frame
	void LoadL () {
		SceneManager.LoadScene("Main");
	}
}
