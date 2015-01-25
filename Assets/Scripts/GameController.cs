using UnityEngine;
using UnityEngine.UI;

// Script to handle the game over-blood effect states
public class GameController : MonoBehaviour 
{
	private int mistakeCount = 0;
	
	public float fadeInTime = 0.75f;
	public float waitTime = 2f;
	public float fadeOutTime = 3.5f;

	public bool gameOn = false;
	
	public Image bloodEffect;
	public GameObject gameOver;
	
	// 0- fade in
	// 1- stay
	// 2- fade out
	private int state = -1;
	private float nextEventTime = -1f;
	
	public void RegisterMistake()
	{
		if (gameOn) {
						mistakeCount++;
		
						if (mistakeCount == 1) {
								nextEventTime = Time.time + fadeInTime;
								state = 0;
						} else if (!gameOver.activeInHierarchy) {
								gameOver.SetActive (true);
								GameObject.FindWithTag ("Music").GetComponent<MusicScript> ().StopMusic ();
						}
				}
	}
	
	void Update()
	{
		switch( state )
		{
			case 0: // fade in
				Color c = bloodEffect.color;
				c.a += Time.deltaTime / fadeInTime;
				bloodEffect.color = c;
				
				if( Time.time > nextEventTime )
				{
					state = 1;
					nextEventTime = Time.time + waitTime;
					
					c = bloodEffect.color;
					c.a = 1;
					bloodEffect.color = c;
				}
				
				break;
				
			case 1: // stay
				if( Time.time > nextEventTime )
				{
					state = 2;
					nextEventTime = Time.time + fadeOutTime;
				}
				
				break;
				
			case 2: // fade out
				Color col = bloodEffect.color;
				col.a -= Time.deltaTime / fadeOutTime;
				bloodEffect.color = col;
				
				if( Time.time > nextEventTime )
				{
					state = -1;
					mistakeCount = 0;
					
					col = bloodEffect.color;
					col.a = 0;
					bloodEffect.color = col;
				}
				
				break;
		}
	}
}
