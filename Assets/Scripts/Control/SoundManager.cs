using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	
	public static SoundManager instance;
	
	void Awake()
	{
		if( !instance ) instance = this;
		else Destroy ( this );
		
		DontDestroyOnLoad(this);
	}
	
	// Use this for initialization
	void Start () 
	{
		GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( Application.loadedLevelName == "EndGame" )
		{
			GetComponent<AudioSource>().volume = .5f;
		}
		else
		{
			if( GetComponent<AudioSource>().volume < 1 )
				GetComponent<AudioSource>().volume = 1;
		}
	}
}
