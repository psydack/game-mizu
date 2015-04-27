using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetScore : MonoBehaviour {
	
	public bool bestScore = true; 

	
	// Use this for initialization
	void Start () {
		if( bestScore )
			GetComponent<Text>().text = PlayerPrefs.GetFloat( "Score", 0).ToString();
		else 
			GetComponent<Text>().text = PlayerPrefs.GetFloat( "LastScore", 0).ToString();
	}
	

}
