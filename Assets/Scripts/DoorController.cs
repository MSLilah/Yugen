using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {


	public bool canEnter = false;	
	public SanityBarController sbc;
	public ItemMenu im;
	
	void Start() 
	{
		sbc = GameObject.FindGameObjectWithTag("GameController").GetComponent<SanityBarController> ();
		im = GameObject.FindGameObjectWithTag("ItemMenu").GetComponent<ItemMenu> ();
	}
	// Update is called once per frame
	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {
			canEnter = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			canEnter = false;
		}
	}

	void Update() {
		if (canEnter && Input.GetKeyDown (KeyCode.E)) {
			im.saveClues();
			sbc.saveSanity();
			PlayerPrefs.SetString("LastKnownLevel", "villageScene");
			Application.LoadLevel("villageScene");
		}
	}
}
