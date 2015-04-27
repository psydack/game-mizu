using UnityEngine;
using System.Collections;

public class SimpleScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = Vector3.one * (Mathf.PingPong(Time.time, .01f)+1);
	}
}
