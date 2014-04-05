using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	public bool canEnter = false;	
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
			Application.LoadLevel("villageScene");
		}
	}
}
