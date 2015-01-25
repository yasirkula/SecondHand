using UnityEngine;

// Script that handles the scale operation
// of the player
public class PlayerScript : MonoBehaviour 
{
	private Transform tr;
	private float spriteHeight;
	private Camera cam;
	
	private Vector2 originScreenPos;
	
	void Start() 
	{
		tr = transform;
		Vector3 scale = tr.localScale;

		tr.localScale = scale;
		cam = Camera.main;
		Sprite s = GetComponentInChildren<SpriteRenderer>().sprite;
		spriteHeight = s.textureRect.height / s.pixelsPerUnit;
		
		originScreenPos = Camera.main.WorldToScreenPoint( 
						new Vector3( 0, 0, -Camera.main.transform.position.z ) );
	}
	
	void Update() 
	{
		if( Input.GetMouseButtonDown( 0 ) )
		{
			Vector2 oldMousePos = Input.mousePosition;
			oldMousePos -= originScreenPos;
		}
		
		// If player is touching the screen
		if( Input.GetMouseButton( 0 ) )
		{
			// Calculate the position in world space and
			// scale accordingly
			Vector2 mousePos = Input.mousePosition;
			Vector2 worldPos = cam.ScreenToWorldPoint( mousePos );
			
			Vector3 scale = tr.localScale;
			scale.y = worldPos.magnitude / spriteHeight;
			if( scale.y > 0.455f )
				scale.y = 0.455f;
			tr.localScale = scale;

		    mousePos = Input.mousePosition;
			mousePos -= originScreenPos;
			
			// rotate the camera and set the score
			// multiplier accordingly
			float angle = Vector2.Angle( Vector2.up, mousePos );
			
			if( mousePos.x > 0 )
				angle = -angle;
		}
	}
}
