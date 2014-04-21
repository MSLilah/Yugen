using UnityEngine;
using System.Collections;

public class ShrineController : MonoBehaviour {

	private bool canRestore = false;
	private SanityBarController sbc;
	public GUIText shrinePrompt;
	// Use this for initialization
	void Start () {
		sbc = GameObject.FindGameObjectWithTag("GameController").GetComponent<SanityBarController> ();
	}

	// Update is called once per frame
	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {
			canRestore = true;
			shrinePrompt.text = "Press E to pray";
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			canRestore = false;
			shrinePrompt.text = "";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (canRestore && Input.GetKeyDown (KeyCode.E)) {
			sbc.currSanity = sbc.maxSanity;
		}
	
	}
}
