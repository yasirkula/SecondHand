using UnityEngine;
using UnityEngine.UI;

// Script to handle multipliers
public class MultiplierScript : MonoBehaviour
{
	public static MultiplierScript instance;
	public Text text;
	
	void Start()
	{
		instance = this;
	}
	
	public static int GetMultiplier()
	{
		return CameraControl.multiplier * NumberScript.multiplier;
	}
	
	// Update multiplier text
	void Update()
	{
		int value = GetMultiplier();
		if( value == 1 )
			text.text = "";
		else
			text.text = "(x" + GetMultiplier() + ")";
	}
}
