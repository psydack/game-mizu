using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	Rigidbody2D rb;
	float force;
	bool insideScreen = false;
	
	public Sprite line;
	public Sprite triangle;
	public Sprite square;
	public Sprite circle;
	public Sprite hexagon;
	
	public AudioClip audioLine;
	public AudioClip audioTrian;
	public AudioClip audioSqr;
	public AudioClip audioCircle;
	public AudioClip audioHex;
	
	// Use this for initialization
	void Start () 
	{
	
		rb = GetComponent<Rigidbody2D>();
		float vel = ((int)Mathf.Log(EnemyControl.instance.level, 3f));
		force = Random.Range(.5f, vel);
		
		GetComponent<CircleCollider2D>().isTrigger = true;
		UseSprite(  (int)(EnemyControl.instance.level / 3)	 );
	}
	
	void Update() {
		if( GameControl.instance.isGameOver ) 
		{
			Destroy (gameObject);
		}
		else
		{
			Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
			rb.AddForce((Vector3.zero - transform.position) * force * Time.smoothDeltaTime);
			
			if ( (screenPosition.x > Screen.width || screenPosition.x < 0) ||  (screenPosition.y > Screen.height || screenPosition.y < 0) )
			{
				if( insideScreen )
				{
					Destroy(gameObject);
					EnemyControl.instance.EnemyDestroied();
				}
			}
			else
			{
				insideScreen = true;
				GetComponent<CircleCollider2D>().isTrigger = false;
			}
		}
	}
	
	
	void UseSprite( int spr )
	{
		Sprite _spr = hexagon;
		AudioClip _audio = audioHex;
		
		switch( spr )
		{
			case 1 : 
				_audio = audioLine;
				_spr = line;
				break;
			case 2 : 
				_audio = audioTrian;
				_spr = triangle;
				break;
			case 3 : 
				_audio = audioSqr;
				_spr = square;
				break;
			case 4 : 
				_audio = audioCircle;
				_spr = circle;
				break;
			case 5 : 
			default:
				_audio = audioHex;
				_spr = hexagon;
				break;
		}
		Camera.main.GetComponent<AudioSource>().PlayOneShot( _audio );
		GetComponent<SpriteRenderer>().sprite = _spr;
	}
}
