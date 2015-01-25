using UnityEngine;

// Code rotating the akrep and yelkovan in the clock
// and initializes their position using the system time
public class IbreScript : MonoBehaviour 
{
	public float rotationSpeed = 15f;
	public bool isAkrep = true;
	
	private Transform tr;
	
	void Start()
	{
		tr = transform;
		
		System.DateTime time = System.DateTime.Now;
		
		// Rotate akrep and yelkovan using system time
		float angle;
		if( !isAkrep )
			angle = time.Minute * 6f;
		else
			angle = ( time.Hour % 12 ) * 30f + time.Minute * 0.5f;
		
		tr.eulerAngles = Vector3.back * angle;
	}
	
	void Update()
	{
		// Rotate the transform over time
		tr.Rotate( Vector3.back * rotationSpeed * UnityEngine.Time.deltaTime );
	}
}
