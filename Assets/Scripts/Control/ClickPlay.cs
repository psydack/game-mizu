using UnityEngine;
using System.Collections;

public class ClickPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if( InputControl.instance )
		{
			InputControl.instance.touchedDown += CheckTouchDown;
		}
	}
	
	void CheckTouchDown(int ID, Vector2 position)
	{
		Vector2 vPos = Camera.main.ScreenToWorldPoint(position);
		if( Physics2D.Raycast( vPos, Vector2.up ) )
		{
			Application.LoadLevel("MizuGame");
		}
		
	}
}
