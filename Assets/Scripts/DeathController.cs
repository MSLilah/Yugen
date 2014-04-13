using UnityEngine;
using System.Collections;

public class DeathController : MonoBehaviour {
	public GUIText gameOverText;
	public GUIText restartText;
	public bool canRestart = false;
	public SanityBarController sbc;
	public ItemMenu im;
	
	void Start() 
	{
		sbc = GameObject.FindGameObjectWithTag("GameController").GetComponent<SanityBarController> ();
		im = GameObject.FindGameObjectWithTag("ItemMenu").GetComponent<ItemMenu> ();
	}

	void Awake() {
		gameOverText.text = "";
		restartText.text = "";
	}
	// Update is called once per frame
	void Update () {
		if (canRestart && gameOverText.text == "") {
			gameOverText.text = "Game Over";
			restartText.text = "Press R to restart from the last door entered";
			im.canNotSeeClues = true;
		}
		if (canRestart && Input.GetKeyDown(KeyCode.R)) {
			print (im.currentLevel);
			Application.LoadLevel(im.currentLevel);
		}
	}
}
