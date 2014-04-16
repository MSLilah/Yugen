using UnityEngine;
using System.Collections;

public class TutorialBoundaryController : MonoBehaviour {
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
		if (atBoundary) 
		{
			GUI.Label (new Rect (Screen.width / 2 - 150, Screen.height / 2 - 150, 500, 300), "Oh NO!! I can't seem to go this way. I should try some where else.");
		}
	}
}
