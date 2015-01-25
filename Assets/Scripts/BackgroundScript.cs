using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour
{
	public float rotationSpeed = 80f;
	private float rotationIncreasePerMinute = 120f;
	private float localTime;
	private Transform tr;
	public static bool start;

	void Start()
	{
		tr = transform;
		start = false;
		rotationIncreasePerMinute /= 60f;
	}

	void Update()
	{
		if( start )
		{
			localTime += Time.deltaTime;

			if( localTime > 14f && localTime < 55f ) 
			{
				rotationSpeed += rotationIncreasePerMinute * UnityEngine.Time.deltaTime;
			}
		}
		
		tr.Rotate( Vector3.forward * rotationSpeed * UnityEngine.Time.deltaTime );
	}
}
