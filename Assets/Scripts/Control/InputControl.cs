using UnityEngine;
using System.Collections;

public class InputControl : MonoBehaviour {
	
	public static InputControl instance;
	
	public bool isDebug = false;
	public GameObject debugSprite;
	/// <summary>
	/// fire when touch and when is touching
	/// </summary>
	public Touched touched;
	public delegate void Touched(int ID, Vector2 position);
	
	/// <summary>
	/// fire when touch is out
	/// </summary>
	public TouchedUp touchedUp;
	public delegate void TouchedUp(int ID, Vector2 position);
	
	/// <summary>
	/// fire when touch is touched first time (began)
	/// </summary>
	public TouchedDown touchedDown;
	public delegate void TouchedDown(int ID, Vector2 position);
	
	
	// Use this for initialization
	void Awake () 
	{
		if( !instance )
			instance = this;
			
		if( isDebug )
		{
			touchedDown += TouchDebug;	
		}
	}
	
	void FixedUpdate()
	{
		#if UNITY_ANDROID || UNITY_IOS
		CheckMobile();
		#else 
		CheckPC();
		#endif
		
	
	}

	void CheckPC()
	{
		if( Input.GetMouseButton(0) )
		{
			if(touched != null)
			{
				touched(0, Input.mousePosition);
			}
		}
		
		if( Input.GetMouseButtonDown(0) )
		{
			if(touchedDown != null)
			{
				touchedDown(0, Input.mousePosition);
			}
		}
		else if( Input.GetMouseButtonUp(0) )
		{
			if(touchedUp != null)
			{
				touchedUp(0, Input.mousePosition);
			}
		}
	}
	
	void CheckMobile()
	{
	
		foreach ( Touch touch in Input.touches )
		{
			
			if ( (touch.phase == TouchPhase.Stationary) || (touch.phase == TouchPhase.Moved))
			{
				touched( touch.fingerId, touch.position );
			}
			if( touch.phase == TouchPhase.Began )
			{
				touchedDown(touch.fingerId, touch.position );
			}
			else if( touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended )
			{
				touchedUp( touch.fingerId, touch.position );
			}

		}
	}
	
	
	void TouchDebug(int ID, Vector2 position)
	{
		Vector3 _pos = Camera.main.ScreenToWorldPoint(position);
		_pos.z = 0;
		GameObject go = Instantiate( debugSprite, _pos, Quaternion.identity ) as GameObject;
		Destroy(go, 2f);
	}
}
