using UnityEngine;
using System.Collections;

public class PlayerCollisionController : MonoBehaviour {
	private FadeController fc;
	private GameCompletionController gcc;

	void Start() {
		fc = GameObject.FindGameObjectWithTag ("Fader").GetComponent<FadeController> ();
		gcc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameCompletionController> ();
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.gameObject.tag == "Player" && !gcc.gameComplete) {
			fc.gameOver = true;
		}
	}
}
