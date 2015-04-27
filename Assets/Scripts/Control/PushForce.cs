using UnityEngine;
using System.Collections;

public class PushForce : MonoBehaviour {
	
	public GameObject goForce;
	
	// Use this for initialization
	void Start () 
	{
		InputControl.instance.touchedDown += TouchedDown;
		InputControl.instance.touched += TouchedDown;
	}
	
	// Update is called once per frame
	void TouchedDown (int ID, Vector2 position) 
	{
	
		if( GameControl.instance.isGameOver ) return;
		
		Vector3 _pos = Camera.main.ScreenToWorldPoint(position);
		_pos.z = 0;
		Instantiate( goForce, _pos, Quaternion.identity );
	}
}
