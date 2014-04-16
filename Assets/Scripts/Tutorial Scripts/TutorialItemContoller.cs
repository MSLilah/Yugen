using UnityEngine;
using System.Collections;

public class TutorialItemContoller : MonoBehaviour {
	
	
	public bool canPickUp = false;	
	public TutorialMenu tm;
	public int clueIdentity;
	public string name;
	private bool itemachieved = false;
	
	void Start() 
	{
		tm = GameObject.FindGameObjectWithTag("TutorialMenu").GetComponent<TutorialMenu> ();
	}
	// Update is called once per frame
	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {
			canPickUp = true;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			canPickUp = false;
		}
		if (itemachieved) 
		{
			Destroy(GameObject.Find (name));
		}
	}
	
	void Update() {
		if (canPickUp && Input.GetKeyDown (KeyCode.E)) {
			itemachieved = true;
			tm.pickedUpClue = clueIdentity;
			tm.newClueFound = true;
		}
	}
	void OnGUI()
	{
		if (canPickUp && !itemachieved) 
		{
			GUI.Label(new Rect(Screen.width/2-100,Screen.height/2-100,200,200),"Press E to Pick Up Clue");
		}
	}
}
