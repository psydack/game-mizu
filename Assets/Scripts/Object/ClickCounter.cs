using UnityEngine;
using System.Collections;

public class ClickCounter : MonoBehaviour {
	
	public GameObject noteFeed;
	public GameObject sprite;
	
	//what bpm we are
	float bpm = 60f;
	//where time its started
	float timeStarted = 0f;
	//when it has clicked
	float clickTime = 0;
	//a bool to check only in update
	bool isClicked = false;
	
	
	// Use this for initialization
	void Start () 
	{
		if( InputControl.instance )
		{
			InputControl.instance.touchedDown += CheckTouchDown;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		
		//if is clicked
		if( isClicked )
		{
			if( GetComponent<BoxCollider2D>().enabled )
			{
				//disable next clicks
				GetComponent<BoxCollider2D>().enabled = false;
				//calculate time when it clicked
				float diff = (Time.fixedTime - timeStarted) - (60.0f / bpm);
				clickTime = (diff) + 1f;
				//fire our controller
				RhythmControl.instance.ScorePlus(clickTime);
				//destroy now
				CreateFeedback(false);
				transform.parent.SendMessage("DestroyAll");
				Destroy(gameObject);
			}
		}
		else
		{
			if( (Time.fixedTime - timeStarted) > 60.0f / bpm )
			{
				//disable next clicks
				GetComponent<BoxCollider2D>().enabled = false;
				//well, it missed
				CreateFeedback(true);
				RhythmControl.instance.MissedClick();
				transform.parent.SendMessage("DestroyAll");
				Destroy(gameObject);
			}
			else
			{
				//simple animation
				sprite.transform.localScale = Vector3.one * 3 * (Time.fixedTime - timeStarted);
			}
		}
	}
	
	public void Setup(float _timeStarted, float _bpm )
	{
		timeStarted = _timeStarted - 0.06f;
		bpm = _bpm;
	}
	
	void CheckTouchDown(int ID, Vector2 position)
	{
		Vector2 vPos = Camera.main.ScreenToWorldPoint(position);
		if( Physics2D.Raycast( vPos, Vector2.up ) )
		{
			isClicked = true;
		}
		
	}
	
	void CreateFeedback(bool missed)
	{
		Vector2 pos = transform.position;
//		pos.y = GetComponent<BoxCollider2D>().bounds.min.y;
		GameObject note = Instantiate( noteFeed, pos, Quaternion.identity ) as GameObject;
		note.GetComponent<NoteFeedback>().PrintFeedback( missed ? 0 : clickTime );
	}
}
