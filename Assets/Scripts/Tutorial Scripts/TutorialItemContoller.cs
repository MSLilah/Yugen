using UnityEngine;
using System.Collections;

public class TutorialItemContoller : MonoBehaviour {
	
	
	public bool canPickUp = false;	
	public TutorialMenu tm;
	public TutorialController tu;
	public int clueIdentity;
	private bool itemachieved = false;
	public Texture clueCommand;
	
	void Start() 
	{
		tm = GameObject.FindGameObjectWithTag("TutorialMenu").GetComponent<TutorialMenu> ();
		tu = GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialController> ();
	}
	// Update is called once per frame
	void OnTriggerStay(Collider other) {
		if (tu.nextPrompt)
		{
				if (other.gameObject.tag == "Player") 
				{
					canPickUp = true;
				}
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			canPickUp = false;
		}
		if (itemachieved) 
		{
			Destroy(this.gameObject);
		}
	}
	
	void Update() {
		if (canPickUp && Input.GetKeyDown (KeyCode.E)) {
			itemachieved = true;
			tm.pickedUpClue = clueIdentity;
			tm.newClueFound = true;
			Destroy(this.gameObject);
		}
	}
	void OnGUI()
	{
		if (canPickUp && !itemachieved) 
		{
			GUI.Label (new Rect (Screen.width-Screen.width/3, 10,300,150), clueCommand);
		}
	}
}
