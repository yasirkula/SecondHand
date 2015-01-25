using UnityEngine;

public class CarkScript : MonoBehaviour 
{
	public float rotationAmountPerSecond = 30f;
	public float rotationIncreasePerMinute = 30f;
	private Transform tr;
	
	void Start()
	{      
		tr = transform;
		rotationIncreasePerMinute /= 10f;
	}
	
	void Update() 
	{
		rotationAmountPerSecond += rotationIncreasePerMinute * UnityEngine.Time.deltaTime;
		tr.Rotate( Vector3.forward * rotationAmountPerSecond * Time.deltaTime );
	}
}
