using UnityEngine;
using System.Collections;

public class BoundaryController : MonoBehaviour {
	public bool atBoundary;
	
	// Use this for initialization
	void Start () {
		atBoundary = false;
		
	}
	void FixedUpdate()
	{
		
	}
	
	// Update is called once per frame
	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {
			atBoundary = true;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			atBoundary = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width/2-250,Screen.height/2 - 500, 300,300), "Oh NO!! I can't seem to leave to the Village!!");
	}
}
