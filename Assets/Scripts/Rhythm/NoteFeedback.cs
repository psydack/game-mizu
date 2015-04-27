using UnityEngine;
using System.Collections;

public class NoteFeedback : MonoBehaviour {

	//just in time ( 1 )
	public Sprite perfect;
	//almost there ( 0.8 ~ 0.89 )
	public Sprite great;
	//a bit great ( 0.7 ~ 0.79 )
	public Sprite early;
	//too early ( 0 ~ 0.69 )
	public Sprite miss;
	
	public void PrintFeedback( float clickTime )
	{
		Sprite _spr;
		//perfect
		if( clickTime >= 0.9f )
		{
			_spr = perfect;
		}
		//great
		else if( clickTime >= 0.8 && clickTime < 0.9f )
		{
			_spr = great;
		}
		//early
		else if( clickTime >= 0.7 && clickTime < 0.8f )
		{
			_spr = early;
		}
		//missed
		else
		{
			_spr = miss;
		}
		
		GetComponent<SpriteRenderer>().sprite = _spr;
		Destroy ( gameObject, 1f );
	}
}
