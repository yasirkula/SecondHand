using UnityEngine;
using UnityEngine.UI;

// Game Over menu script
public class GameOverScript : MonoBehaviour 
{
	public Image background;
	public Text scoreText;
	public Text restart;
	private string targetText;
	private float nextTime;
	private int charIndex = 0;
	private bool moveCamera = false;
	
	void Start()
	{
		targetText = "Score: " + ScoreScript.instance.GetScore() + 
						 "\nHighscore: " + ScoreScript.instance.GetHighscore();
		scoreText.text = "";
		nextTime = Time.time + 0.05f;
	}
	
	void Update()
	{
		if( Time.time > nextTime )
		{
			nextTime = Time.time + 0.05f;
			if( charIndex < targetText.Length )
				scoreText.text += targetText[charIndex++];
		}
		
		Color c = background.color;
		c.a += Time.deltaTime;
		background.color = c;
		
		c = restart.color;
		c.a += Time.deltaTime;
		restart.color = c;
		
		if( !moveCamera && c.a >= 1f )
		{
			moveCamera = true;
			Camera.main.transform.position = Vector3.one * 1000;
		}
	}
	
	public void Restart()
	{
		Application.LoadLevel( Application.loadedLevel );
	}
}
