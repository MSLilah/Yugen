using UnityEngine;
using System.Collections;

public class SanityEffectController : MonoBehaviour {
	private SanityBarController sbc;
	private Light light;
	private Color insaneLight;

	private bool writingDisplay = false;
	private bool changeToWriting = true;

	private GUIStyle style;
	private Texture2D texture;

	public Material writing;
	public Material normalWall;
	// Use this for initialization
	void Start () {
		sbc = GetComponent<SanityBarController>();
		light = GameObject.FindGameObjectWithTag ("Light").light;
		insaneLight = new Color32 (193, 101, 101, 255);
		style = new GUIStyle();
		texture = new Texture2D(128, 128);
	}
	
	// Update is called once per frame
	void Update () {
		if (sbc.currSanity < 50f) {
			light.color = insaneLight;
		}
		else if (light.color != Color.white) {
			light.color = Color.white;
		}
		if (sbc.currSanity < 25f && !writingDisplay) {
			WritingOnTheWall(writing);
			writingDisplay = true;
		}
		else if (sbc.currSanity > 25f && writingDisplay) {
			WritingOnTheWall(normalWall);
		}
	}

	void WritingOnTheWall(Material m) {
		GameObject[] walls = GameObject.FindGameObjectsWithTag ("Wall");
		for (int i = 0; i < walls.Length; i++) {
			walls[i].renderer.material = m;
		}
	}
}
