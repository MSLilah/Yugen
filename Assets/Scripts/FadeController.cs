using UnityEngine;
using System.Collections;

public class FadeController : MonoBehaviour {

	public float fadeSpeed = 1.0f;
	public bool gameOver = false;
	private DeathController dc;
	private StaminaBarController sbc;
	private GameCompletionController gcc;

	void Awake () {
		guiTexture.pixelInset = new Rect(-1f, -1f, Screen.width, Screen.height);
		guiTexture.enabled = false;
		guiTexture.color = Color.clear;
		dc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<DeathController> ();
		gcc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameCompletionController> ();
		sbc = GameObject.FindGameObjectWithTag ("Player").GetComponent<StaminaBarController>();
	}

	void Update () {
		if (gameOver) {
			EndScene();
			sbc.gameOver = true;
		}
	}

	void FadeToBlack() {
		guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
	}

	void EndScene() {
		// Make sure the texture is enabled.
		guiTexture.enabled = true;
		
		// Start fading towards black.
		FadeToBlack();
		
		// If the screen is almost black...
		if (guiTexture.color.a >= 0.95f && !gcc.gameComplete) {
			//...Display the restart text and enable restarting
			dc.canRestart = true;
		}
		else if (guiTexture.color.a >= 0.95f && gcc.gameComplete) {
			//TODO: SWITCH TO END SCREEN
		}

	}
}
