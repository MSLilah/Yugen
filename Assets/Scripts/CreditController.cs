﻿using UnityEngine;
using System.Collections;

public class CreditController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(50,50,130,50), "Back to Main Menu")) {
			Application.LoadLevel("Main Menu");
		}		
		
	}
}
