using UnityEngine;
using System.Collections;

public class GoForce : MonoBehaviour {
	
	float timeStarted = 0;
	Color c;
	float timeToDie = 1.8f;
	
	// Use this for initialization
	void Start () {
		timeStarted = Time.time;
		c = GetComponent<SpriteRenderer>().color;
		Destroy(gameObject, timeToDie);
	}
	
	// Update is called once per frame
	void Update () {
		if( GameControl.instance.isGameOver ) 
		{
			Destroy (gameObject);
		}
		else
		{
			timeToDie -= Time.deltaTime;
			c.a = Mathf.MoveTowards(timeToDie, 0, 0);
			transform.localScale = Vector2.one * (Time.time - timeStarted + .2f);
			GetComponent<SpriteRenderer>().color = c;
		}
	}
	
	
}
