using UnityEngine;
using System.Collections;

public class Ilha : MonoBehaviour {
	

	
	// Use this for initialization
	void Start () {
	
	}
	
	
	
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if( coll.CompareTag("Enemy") )
		{
			ApplyDamage();
		}
	}
	
	void ApplyDamage()
	{
		GameControl.instance.EndGame();
	}
}
