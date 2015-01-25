using UnityEngine;

// Script that handles positioning the
// light effect
public class PointerEffect : MonoBehaviour 
{
	public Transform lightObject;
	private Camera cam;
	
	void Start()
	{
		cam = Camera.main;
	}
	
	void Update() 
	{
		// If user is touching the screen
		if( Input.GetMouseButton( 0 ) )
		{
			// Position the light effect
			Vector2 mousePos = Input.mousePosition;
			Vector3 mouseRealPos = cam.ScreenToWorldPoint( 
									new Vector3( mousePos.x, mousePos.y, 17.75f ) );
			lightObject.position = mouseRealPos;
		}
	}
}
