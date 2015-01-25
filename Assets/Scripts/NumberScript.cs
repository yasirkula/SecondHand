using UnityEngine;
using UnityEngine.UI;

// Script handling the numbers on the clock
public class NumberScript : MonoBehaviour 
{
	private bool isVisible = false;
	private bool fadeOut = false;
	private Collider2D c;
	private Transform tr;
	private Text text;
	
	public static int comboCount = 0;
	public static int multiplier = 1;
	
	// particle effect to create when collided with
	// the saniye hand
	public GameObject particlePrefab;
	
	void Awake()
	{
		tr = transform;
		text = GetComponent<Text>();
		c = GetComponent<Collider2D>();
		
		comboCount = 0;
		multiplier = 1;
	}
	
	void Update() 
	{
		if( tr.position.y > -2f )
		{
			isVisible = true;
			
			if( fadeOut )
			{
				Color co = text.color;
				co.a -= 3f * UnityEngine.Time.deltaTime;
				text.color = co;
			}
		}
		else if( isVisible )
		{
			// if the text is no longer visible,
			// change its y-location randomly
			isVisible = false;
			c.enabled = true;
			fadeOut = false;
			
			Color co = text.color;
			co.a = 1f;
			text.color = co;
			
			tr.localPosition = Vector3.up * NumberCreator.GetYPos();
		}
	}
	
	void OnTriggerEnter2D( Collider2D c2D )
	{
		// If we collided with the saniye hand
		if( c2D.tag == "Player" )
		{
			// Increase the score
			ScoreScript.instance.ChangeScore( 1 );
			
			comboCount++;
			if( comboCount >= 12 )
			{
				comboCount = 0;
				multiplier++;
			}
			
			// Fade out the text
			c.enabled = false;
			fadeOut = true;
			
			// Create particle effect
			if( particlePrefab )
			{
				GameObject g = Instantiate( particlePrefab, tr.position, Quaternion.identity ) as GameObject;
				g.renderer.sharedMaterial.SetColor( "_TintColor", text.color );
			}
		}
	}
}
