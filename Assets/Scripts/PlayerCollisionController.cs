using UnityEngine;
using System.Collections;

public class PlayerCollisionController : MonoBehaviour {
	FadeController fc;

	void Start() {
		fc = GameObject.FindGameObjectWithTag ("Fader").GetComponent<FadeController> ();
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.gameObject.tag == "Player") {
			fc.gameOver = true;
		}
	}
}
