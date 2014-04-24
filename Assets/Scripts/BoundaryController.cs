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

	}
}
