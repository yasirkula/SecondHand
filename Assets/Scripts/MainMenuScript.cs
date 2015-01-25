using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuScript : MonoBehaviour 
{
	// 0 init FadeOut 0.5 
	// 1 init title appears 
	// 2 wait
	// 3 buttonPress tutorial fadein
	// 4 buttonPress fadein
	// 5 init components real game
	// 6 complete fade out init real game
	// 7 wait for destruction
	private int state;

	public Image img;
	public Image holdHere;
	public Text title;
	public Text tutorial;
	public GameObject UI;
	public Collider2D playerCollider;
	public Collider2D garbageCollider;
	public PlayerScript playerScript;
	public CameraControl cameraScript;
	public AudioSource music;
	
	void Awake() 
	{
		// initial state
		state = 0;
		
		// start the game with the second hand at its
		// maximum length
		Vector3 s = playerScript.transform.localScale;
		s.y = 0.455f;
		playerScript.transform.localScale = s;
	}
	
	void Update() 
	{
		switch( state ) 
		{
			case 0:
				Color col = img.color;
				col.a -= Time.deltaTime;
				img.color = col;
				if( col.a <= 0.5f )
					state = 1;
				break;
			case 1:
				Color col2 = title.color;
				col2.a += Time.deltaTime;
				title.color = col2;
				if( col2.a >= 1f )
					state = 2;
				break;
			case 2:
				if( Input.GetMouseButtonDown( 0 ) ) 
					state = 3;
				break;
			case 3:
				title.transform.Translate( Vector3.left * 1000 * Time.deltaTime );
				
				Color c = tutorial.color;
				c.a += Time.deltaTime;
				tutorial.color = c;
				holdHere.color = c;

				if( c.a >= 1f && Input.GetMouseButtonDown( 0 ) )
				{
					state = 4;
					music.enabled = true;
				}
				break;
			case 4:
				Color col3 = img.color;
				col3.a += Time.deltaTime;
				img.color = col3;
				
				Color col3_2 = title.color;
				col3_2.a -= 2f * Time.deltaTime;
				title.color = col3_2;
				holdHere.color = col3_2;
				tutorial.color = col3_2;

				if( col3.a >= 1f )
					state = 5;
				break;
			case 5:
				UI.SetActive( true );
				playerCollider.enabled = true;
				playerScript.enabled = true;
				cameraScript.enabled = true;
				state = 6;
				break;
			case 6:
				Color col4 = img.color;
				col4.a -= Time.deltaTime;
				img.color = col4;
				if( col4.a <= 0f )
				{
					BackgroundScript.start = true;
					StartCoroutine( ActivateGarbage() );
					state = 7;
				}
					
				break;
		}
	}
	
	IEnumerator ActivateGarbage()
	{
		yield return new WaitForSeconds( 4f );
		garbageCollider.enabled = true;
		Destroy( gameObject );
	}
}
