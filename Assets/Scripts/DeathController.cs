using UnityEngine;
using System.Collections;

public class DeathController : MonoBehaviour {
	public GUIText gameOverText;
	public GUIText restartText;
	public bool canRestart = false;

	void Awake() {
		gameOverText.text = "";
		restartText.text = "";
	}
	// Update is called once per frame
	void Update () {
		if (canRestart && gameOverText.text == "") {
			gameOverText.text = "Game Over";
			restartText.text = "Press R to restart from the last door entered";
		}
		if (canRestart && Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel(0);
		}
	}
}
