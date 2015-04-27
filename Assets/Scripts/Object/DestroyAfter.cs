using UnityEngine;
using System.Collections;

public class DestroyAfter : MonoBehaviour {

	public void DestroyAll()
	{
		Invoke ("DestroyMe", 60.0f / (RhythmControl.instance.bpm * 4f) );
	}
	
	void DestroyMe()
	{
		Destroy(gameObject);
	}
}
