using UnityEngine;
using System.Collections;

public class TutorialShrineController : MonoBehaviour {

	private bool canRestore = false;
	private SanityBarController sbc;
	public Texture shrineCommand;
	public TutorialController tu;
	// Use this for initialization
	void Start () {
		sbc = GameObject.FindGameObjectWithTag("GameController").GetComponent<SanityBarController> ();
		tu = GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialController> ();
	}

	// Update is called once per frame
	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {
			canRestore = true;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			canRestore = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (canRestore && Input.GetKeyDown (KeyCode.E)) {
			sbc.currSanity = sbc.maxSanity;
			tu.taskIsComplete = true;
			Destroy(this.gameObject);
		}
	
	}

	void OnGUI()
	{
		if (canRestore) 
		{
			GUI.Label (new Rect (Screen.width-Screen.width/3, 10,300,150), shrineCommand);
		}
	}
}
