using UnityEngine;
using System.Collections;

public class FadeController : MonoBehaviour {

	public float fadeSpeed = 1.0f;
	public bool gameOver = false;
	private DeathController dc;
	
	void Awake () {
		guiTexture.pixelInset = new Rect(-1f, -1f, Screen.width, Screen.height);
		guiTexture.enabled = false;
		guiTexture.color = Color.clear;
		dc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<DeathController> ();
	}

	void Update () {
		if (gameOver) {
			EndScene();
			GameObject.FindGameObjectWithTag ("Player").GetComponent<StaminaBarController>().gameOver = true;
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
		if (guiTexture.color.a >= 0.95f) {
			//...Display the restart text and enable restarting
			dc.canRestart = true;
		}
	}
}
