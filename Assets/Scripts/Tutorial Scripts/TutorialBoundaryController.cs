using UnityEngine;
using System.Collections;

public class TutorialBoundaryController : MonoBehaviour {
	public bool atBoundary;
	public Texture tutorialBoundary;

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
			GUI.Label (new Rect (Screen.width-Screen.width/3, 10,300,150), tutorialBoundary);
		}
	}
}
