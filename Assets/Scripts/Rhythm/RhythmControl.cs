using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RhythmControl : MonoBehaviour {
	
	
	//// <summary>
	/// The bpm of level.
	/// </summary>
	public float bpm = 60f;
	
	/// <summary>
	/// The instance of Rhythm.
	/// </summary>
	public static RhythmControl instance;
	
	//for instance of object on scene
//	float counter = 0;
	public GameObject clickPoint;
	
	//score
	public float score { get { return _score; } }
	float _score = 0;
	int combo = 0;
	
	
	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake()
	{
		if( !instance ) instance = this;
		Invoke("Step", 60.0f / bpm );
	}
	
	// Update is called once per frame
	bool half = false;
	void FixedUpdate () 
	{
//		counter += Time.fixedDeltaTime;
//		if( counter > 60.0f / bpm )
//		{
//			counter = 0;
//			Camera.main.GetComponent<AudioSource>().Play();
//			//put new object on scene
//			Vector3 randomPosition = new Vector3( Random.Range(100, Screen.width - 100), Random.Range(100, Screen.height - 100), Camera.main.transform.position.z * -1);
//			GameObject cp = Instantiate( clickPoint, Camera.main.ScreenToWorldPoint( randomPosition ), Quaternion.identity ) as GameObject;
//			//what time is it
//			//and what is actual bpm when is created
//			cp.GetComponentInChildren<ClickCounter>().Setup( Time.fixedTime, bpm );
//			
//		}
		
		if(!half && Time.time > 2f )
		{
			half = true;
			StepHalf();
		}
		
	}
	
	
	void Step()
	{
		Camera.main.GetComponent<AudioSource>().Play();
		//put new object on scene
		Vector3 randomPosition = new Vector3( Random.Range(100, Screen.width - 100), Random.Range(100, Screen.height - 100), Camera.main.transform.position.z * -1);
		GameObject cp = Instantiate( clickPoint, Camera.main.ScreenToWorldPoint( randomPosition ), Quaternion.identity ) as GameObject;
		//what time is it
		//and what is actual bpm when is created
		cp.GetComponentInChildren<ClickCounter>().Setup( Time.fixedTime, bpm );
		
		Invoke ( "Step", 60.0f / bpm );
	}
	
	void StepHalf()
	{
		Camera.main.GetComponent<AudioSource>().Play();
		//put new object on scene
		Vector3 randomPosition = new Vector3( Random.Range(100, Screen.width - 100), Random.Range(100, Screen.height - 100), Camera.main.transform.position.z * -1);
		GameObject cp = Instantiate( clickPoint, Camera.main.ScreenToWorldPoint( randomPosition ), Quaternion.identity ) as GameObject;
		//what time is it
		//and what is actual bpm when is created
		cp.GetComponentInChildren<ClickCounter>().Setup( Time.fixedTime, bpm );
		
		Invoke ( "StepHalf", 60.0f / (bpm * 2) );
	}

	
	public void ScorePlus(float time)
	{	
		if( time > 0.6f )
		{
			float _sc = (100 * time) * (combo + 1);
			_score += _sc;
			combo ++;
		}
		else
		{
			MissedClick();
		}
	}
	
	public void MissedClick()
	{
		combo = 0;
	}

}
