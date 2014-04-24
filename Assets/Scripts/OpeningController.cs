using UnityEngine;
using System.Collections;

public class OpeningController : MonoBehaviour {
	
	public Texture letter;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	
	void OnGUI()
	{
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(Screen.width - 150, Screen.height - 100,120,50), "Start Game")) {
			PlayerPrefs.SetInt ("GameExist", 1);
			Application.LoadLevel("villageScene");
		}
		
		GUI.Label(new Rect ((Screen.width/3), 10, Screen.width/2.5f, Screen.height), letter);		
	}
}
