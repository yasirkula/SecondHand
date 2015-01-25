using UnityEngine;

// Script that handles rotation of the camera
public class CameraControl : MonoBehaviour 
{
	Vector2 originScreenPos;
	
	// score multiplier
	public static int multiplier = 1;
	private float oldAngle;
	private Transform tr;
	public GameObject background;
	
	void Start() 
	{
		tr = transform;
		originScreenPos = Camera.main.WorldToScreenPoint( 
						new Vector3( 0, 0, -Camera.main.transform.position.z ) );
	}
	
	void Update() 
	{
		if( Input.GetMouseButton( 0 ) )
		{
			Vector2 mousePos = Input.mousePosition;
			mousePos -= originScreenPos;
			
			// rotate the camera and set the score
			// multiplier accordingly
			float angle = Vector2.Angle( Vector2.up, mousePos );
			
			if( mousePos.x < 0 )
				angle = -angle;
				
			float deltaAngle = angle - oldAngle;
			
			if ( angle < -30f )
				angle = -30f;
			else if( angle < -20f )
				multiplier = 1;
			else if( angle < 20f )
				multiplier = 2;
			else if ( angle < 30f )
				multiplier = 3;
			else
				angle = 30f;
			
			float angulerSpeed = deltaAngle/Time.deltaTime;
			tr.eulerAngles = Vector3.forward * ( angle );
			if( deltaAngle > 0 && angle < 30 )
				background.transform.Rotate (Vector3.forward * angulerSpeed * UnityEngine.Time.deltaTime);
				
			oldAngle = angle;
		}
	}
}
