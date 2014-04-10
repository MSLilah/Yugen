using UnityEngine;
using System.Collections;

public class SanityEffectController : MonoBehaviour {
	private SanityBarController sbc;
	private Light light;
	private Color insaneLight;
	// Use this for initialization
	void Start () {
		sbc = GetComponent<SanityBarController>();
		light = GameObject.FindGameObjectWithTag ("Light").light;
		insaneLight = new Color32 (193, 101, 101, 255);
	}
	
	// Update is called once per frame
	void Update () {
		if (sbc.currSanity < 50f) {
			light.color = Color.Lerp (Color.white, insaneLight, 1.0f);
		}
		else if (light.color != Color.white) {
			light.color = Color.Lerp (insaneLight, Color.white, 1.0f);
		}
	}
}
