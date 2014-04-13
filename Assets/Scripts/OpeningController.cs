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
		if(GUI.Button(new Rect(100,((Screen.height/2)-50),120,100), "Start Game")) {
			Application.LoadLevel("villageScene");
		}

		GUI.Label(new Rect ((Screen.width/2)-140, 10, (Screen.width - 140), Screen.height), letter);

		
	}
}
	