using UnityEngine;
using System.Collections;

public class TutorialItemContoller : MonoBehaviour {
	
	
	public bool canPickUp;	
	public TutorialMenu tm;
	public TutorialController tu;
	public int clueIdentity;
	private bool itemachieved;
	public Texture clueCommand;
	private SanityBarController sbc;
	
	void Start() 
	{
		itemachieved = false;
		canPickUp = false;
		tm = GameObject.FindGameObjectWithTag("TutorialMenu").GetComponent<TutorialMenu> ();
		tu = GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialController> ();
		sbc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<SanityBarController> ();
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
	}
	
	void Update() {
		if (canPickUp && Input.GetKeyDown (KeyCode.E)) {
			itemachieved = true;
			tm.pickedUpClue = clueIdentity;
			tm.newClueFound = true;
			Destroy(this.gameObject);
			sbc.currSanity -= 25;
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
