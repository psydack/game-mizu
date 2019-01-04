using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
	
	
	int score = 0;
	float timeLevelStarted = 0;
	
	public bool isGameOver = false;
	
	public static GameControl instance;
	
	void Start()
	{
		if( !instance ) instance = this;
	}
	
	
	public void StartLevel()
	{
		timeLevelStarted = Time.time;
	}
	
	public void EndLevel()
	{	
		float _enemies = (int)Mathf.Log(EnemyControl.instance.level, 2f) + 1;
		float timeToEnd = ( ( 3 * (Mathf.Log(EnemyControl.instance.level, 2f) + 1) ) * _enemies);
		timeToEnd = timeToEnd - ( Time.time - timeLevelStarted );
		if( timeToEnd < 0 ) timeToEnd = 0; 
		
		float _score = (_enemies * 100) + (timeToEnd * 100);
		score += (int)_score;
	}
	
	public void EndGame()
	{
		PlayerPrefs.SetFloat( "LastScore", score);
		
		if( score > PlayerPrefs.GetFloat( "Score", 0) )
		{
			PlayerPrefs.SetFloat( "Score", score);
		}
		
		SceneManager.LoadScene("EndGame");
	}
}
