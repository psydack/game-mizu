using UnityEngine;
using System.Collections;

public class SimpleRotation : MonoBehaviour {
	
	public float velocity = 2f;
	
	public bool random = true;
	// Use this for initialization
	void Start () 
	{
		transform.localEulerAngles = Vector3.forward * Random.Range(0f, 360.0f);
		
		if( random )
			velocity = Random.Range( -4f, 4f );
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate( Vector3.forward * velocity );
		
	}
}
