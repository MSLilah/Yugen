using UnityEngine;
using System.Collections;

public class GameCompletionController : MonoBehaviour {

	private FadeController fc;
	private SanityBarController sbc;
	public bool gameComplete = false;
	// Use this for initialization
	void Start () {
		fc = GameObject.FindGameObjectWithTag ("Fader").GetComponent<FadeController>();
		sbc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<SanityBarController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameComplete) {
			sbc.currSanity -= 0.1f;
			if (sbc.currSanity <= 0) {
				fc.gameOver = true;
			}
		}
	}
}
