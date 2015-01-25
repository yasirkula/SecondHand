using UnityEngine;
using UnityEngine.UI;

// Script to manage score related operations
public class ScoreScript : MonoBehaviour 
{
	public int skor;
	public static ScoreScript instance;
	public Text skorText;
	
	void Awake()
	{
		instance = this;

		skorText.text = "";
		skor = 0;
	}
	
	//called by NumberScript to increase the score
	public void ChangeScore( int delta )
	{
		delta *= MultiplierScript.GetMultiplier();
		skor += delta;
		
		if( Application.loadedLevelName == "DiscoTheme" )
		{
			skorText.text = skor.ToString();
		}
		else
		{
			skorText.text = IntegerToRomanNumeral( skor );
		}
	}
	
	public int GetScore()
	{
		if( skor > PlayerPrefs.GetInt( "Highscore" ) )
			PlayerPrefs.SetInt( "Highscore", skor );
		return skor;
	}
	
	public int GetHighscore()
	{
		return PlayerPrefs.GetInt( "Highscore" );
	}

	public static string IntegerToRomanNumeral( int input )
	{
		/* Credit to:
		http://stackoverflow.com/questions/12967896/converting-integers-to-roman-numerals-java
		posted by: user1752197
		*/
		if( input < 1 || input > 3999 )
			return "SCORE IS TOO AWESOME TO SHOW";
			
		string s = "";
		while( input >= 1000 )
		{
			s += "M";
			input -= 1000;        
		}
		while( input >= 900 )
		{
			s += "CM";
			input -= 900;
		}
		while( input >= 500 )
		{
			s += "D";
			input -= 500;
		}
		while( input >= 400 )
		{
			s += "CD";
			input -= 400;
		}
		while( input >= 100 )
		{
			s += "C";
			input -= 100;
		}
		while( input >= 90 )
		{
			s += "XC";
			input -= 90;
		}
		while( input >= 50 )
		{
			s += "L";
			input -= 50;
		}
		while( input >= 40 )
		{
			s += "XL";
			input -= 40;
		}
		while( input >= 10 ) 
		{
			s += "X";
			input -= 10;
		}
		while( input >= 9 )
		{
			s += "IX";
			input -= 9;
		}
		while( input >= 5 )
		{
			s += "V";
			input -= 5;
		}
		while( input >= 4 )
		{
			s += "IV";
			input -= 4;
		}
		while( input >= 1 )
		{
			s += "I";
			input -= 1;
		}    
		
		return s;
	}
}
