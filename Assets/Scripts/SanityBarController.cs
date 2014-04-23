using UnityEngine;
using System.Collections;

public class SanityBarController : MonoBehaviour {
	
	public float maxSanity = 100f;
	public float currSanity = 100f;
	public bool gameCompleted = false;
	private float sanityBarLength;
	private GUIStyle style;
	private Texture2D texture;
	private FadeController fc;
	private bool writingOnWall = false;
	private bool changeToWriting = false;
	
	// Use this for initialization
	void Start () {
		currSanity = PlayerPrefs.GetFloat ("SanityLevel", 100f);
		maxSanity = PlayerPrefs.GetFloat ("MaxSanityLevel", 100f);
		sanityBarLength = Screen.width / 2;
		style = new GUIStyle();
		texture = new Texture2D(128, 128);
		fc = GameObject.FindGameObjectWithTag ("Fader").GetComponent<FadeController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currSanity > maxSanity) {
			currSanity = maxSanity;
		}
		sanityBarLength = (Screen.width / 2) * (currSanity / 100f);
	}
	
	void OnGUI() {
		if (fc.gameOver == false) {
			texture.SetPixel (0, 0, Color.white);
			texture.Apply ();
			style.normal.background = texture;
			GUI.backgroundColor = new Color (136, 0, 0, 255);
			GUI.Box (new Rect (10, 40, sanityBarLength, 20), "", style);
			GUI.backgroundColor = Color.white;
		}
	}

	public void saveSanity()
	{
		PlayerPrefs.SetFloat ("MaxSanityLevel", maxSanity);
		PlayerPrefs.SetFloat ("SanityLevel", currSanity);
	}
}
