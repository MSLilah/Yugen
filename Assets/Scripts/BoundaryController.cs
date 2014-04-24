using UnityEngine;
using System.Collections;

public class BoundaryController : MonoBehaviour {
	public bool atBoundary;
	public Texture boundaryImage;
	public Texture riverBoundaryImage;
	
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

			if(this.gameObject.tag.Equals("River"))
			{
				//GUI.Label (new Rect (Screen.width-Screen.width/3, 10,300,150), riverBoundaryImage);
			}
			else
			{
				//GUI.Label (new Rect (Screen.width-Screen.width/3, 10,300,150), boundaryImage);
			}
		}
	}
}
