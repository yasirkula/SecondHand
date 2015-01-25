using UnityEngine;

// Script to handle music
public class MusicScript : MonoBehaviour 
{
	private AudioSource a;
	private bool fadeOut = false;
	public float musicSpeedIncrement = 0.5f;
	
	void Awake() 
	{
		a = audio;
	}
	
	void Update() 
	{
		a.pitch += Time.deltaTime * musicSpeedIncrement;
		
		if( fadeOut )
		{
			a.volume -= Time.deltaTime;
		}
	}
	
	public void StopMusic()
	{
		fadeOut = true;
	}
}
