using UnityEngine;

// Class to handle missed texts
public class GarbageCollection : MonoBehaviour 
{
	public GameController gc;

	
	void OnTriggerEnter2D( Collider2D c2D )
	{
		// a text is missed, punish the player
		if( c2D.tag == "Text" )
		{
			NumberScript.comboCount = 0;
			NumberScript.multiplier = 1;
			gc.gameOn = true;
			gc.RegisterMistake();
		}
	}
}
