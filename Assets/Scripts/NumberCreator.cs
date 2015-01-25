using UnityEngine;
using UnityEngine.UI;

// Creates 12 UI Texts to represent hours in the clock
public class NumberCreator : MonoBehaviour 
{
	// limit points
	private static float bottomPoint;
	private static float topPoint;
	
	// should the numbers be in roman format
	public bool romanMode = false;
	
	// object that helps us identify the position
	// of the topmost point of the clock
	public Transform topPointObject;
	
	// UI Text prefab
	public GameObject numberPrefab;
	
	// Color tint effect variables for disco mode
	public static Color tintColor = Color.white;
	private static Vector3 renkRGB = Vector3.one;
	
	void Start() 
	{
		// Calculate limit points
		bottomPoint = Camera.main.ViewportToWorldPoint( 
				new Vector3( 0.5f, 0f, -Camera.main.transform.position.z ) ).y + 1.2f;
	
		topPoint = topPointObject.position.y;
		
		renkRGB = Vector3.one;
		
		// Create numbers as UI Texts
		for( int i = 1; i <= 12; i++ )
		{
			// Instantiate and position the number
			GameObject number = Instantiate( numberPrefab ) as GameObject;
			number.transform.position = Vector3.zero;
			Transform child = number.transform.GetChild(0);
			number.transform.eulerAngles = Vector3.back * i * 30f;
			child.localPosition = new Vector3( 0, Random.Range( bottomPoint, topPoint ), -0.5f );
			
			// Set the UI Text's content
			if( !romanMode )
				child.GetComponent<Text>().text = i.ToString();
			else
				child.GetComponent<Text>().text = ScoreScript.IntegerToRomanNumeral(i);
				
			// Let all UI Text's child of this canvas
			number.transform.parent = transform;
			
			// Rename the UI Text for better readability
			number.name = i.ToString(); 
			
			// Numbers from 9 to 12 should not trigger
			// game over event at the beginning of
			// the game
			if( i >= 9 )
			{
				child.GetComponent<Collider2D>().enabled = false;
			}
		}
		
		// Start with a random color in disco mode
		renkRGB = Random.insideUnitSphere;
	}
	
	void Update()
	{
		// Tilt the color randomly
		renkRGB += new Vector3( 0.05f, 0.1f, 0.15f ) * UnityEngine.Time.deltaTime;
		tintColor.r = Mathf.PingPong( renkRGB.x, 1f );
		tintColor.g = Mathf.PingPong( renkRGB.y, 1f );
		tintColor.b = Mathf.PingPong( renkRGB.z, 1f );
	}
	
	public static float GetYPos()
	{
		// Return a random position for UI Texts
		return Random.Range( bottomPoint, topPoint );
	}
}
