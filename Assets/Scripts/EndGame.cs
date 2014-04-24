using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (GUI.Button (new Rect (Screen.width - 200, Screen.height- 150, 150, 75), "Return to Main Menu")) {
			Application.LoadLevel ("Main Menu");
		}
	}
}
