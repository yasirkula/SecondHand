using UnityEngine;
using UnityEngine.UI;

// Tilts the color of the object over time
public class ColorizeMe : MonoBehaviour 
{
	private SpriteRenderer sRenderer;
	private Text text;
	
	void Start() 
	{
		sRenderer = GetComponent<SpriteRenderer>();
		text = GetComponent<Text>();
	}
	
	void Update()
	{
		if( sRenderer )
		{
			// If this object has sprite renderer
			sRenderer.color = NumberCreator.tintColor;
		}
		else if( text )
		{
			// If this object has UI Text
			Color c = NumberCreator.tintColor;
			c.a = text.color.a;
			text.color = c;
		}
	}
}
