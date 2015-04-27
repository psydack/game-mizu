using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {
	
	public GameObject enemy;
	public int level = 1;
	
	public int enemySpawners = 0;
	
	public static EnemyControl instance;
	
	// Use this for initialization
	void Start () 
	{
		if( !instance ) instance = this;
		StartCoroutine ( NextLevel() );
	}
	

	
	void SpawnEnemy()
	{
		if( GameControl.instance.isGameOver )  return;
		
		enemySpawners++;
		
		Vector3 pos = Vector3.zero;
		int rnd = Random.Range (1, 4);
		if( rnd == 1 )
			pos = new Vector3(0, Random.Range ( 0, Screen.height ), -Camera.main.transform.position.z);
		else if ( rnd == 2 )
			pos = new Vector3(Screen.width, Random.Range ( 0, Screen.height ), -Camera.main.transform.position.z);
		else if ( rnd == 3 )
			pos = new Vector3(Random.Range ( 0, Screen.width ), 0, -Camera.main.transform.position.z);
		else 
			pos = new Vector3(Random.Range ( 0, Screen.width ), Screen.height, -Camera.main.transform.position.z);
		
		pos = Camera.main.ScreenToWorldPoint(pos);
		Instantiate(enemy, pos, Quaternion.identity );
		
	}
	
	
	public void EnemyDestroied()
	{
		enemySpawners--;
		if( enemySpawners <= 0 )
		{
			GameControl.instance.EndLevel();
			level++;
			StartCoroutine ( NextLevel() );
		}
	}
	
	IEnumerator NextLevel()
	{
		if( GameControl.instance )
		{
			GameControl.instance.StartLevel();
			
			int spawnEn = (int)Mathf.Log(level, 2f) + 1 + (int)(level%4);
			for(int i = 0; i < spawnEn; i++)
				SpawnEnemy();
		}
		else
		{
			yield return new WaitForEndOfFrame();
			StartCoroutine( NextLevel() );
			yield return null;
		}	
		
			
		yield return null;
	}
}
