using UnityEngine;
using System.Collections;

public class SanityEffectController : MonoBehaviour {
	private SanityBarController sbc;
	private GameObject[] lights;
	private Color insaneLight;

	private bool writingDisplay = false;
	private bool changeToWriting = true;
	private bool falseEnemySpawned = false;

	private GUIStyle style;
	private Texture2D texture;

	public Material writing;
	public Material normalWall;

	public GameObject falseEnemy;

	private Transform player;
	// Use this for initialization
	void Start () {
		sbc = GetComponent<SanityBarController>();
		lights = GameObject.FindGameObjectsWithTag ("Light");
		insaneLight = new Color32 (193, 101, 101, 255);
		style = new GUIStyle();
		texture = new Texture2D(128, 128);
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (sbc.currSanity < 50f) {
			byte gb = (byte)(101 - (2 * (50 - sbc.currSanity)));
			insaneLight = new Color32(193, gb, gb, 255);
			SetLightColor(insaneLight);
		}
		else if (lights[0].light.color != Color.white) {
			SetLightColor(Color.white);
		}
		if (sbc.currSanity < 35f && !writingDisplay) {
			WritingOnTheWall(writing);
			writingDisplay = true;
		}
		else if (sbc.currSanity > 35f && writingDisplay) {
			WritingOnTheWall(normalWall);
		}

		if (sbc.currSanity < 20f && !falseEnemySpawned) {
			SpawnFalseEnemy();
		}
	}

	void WritingOnTheWall(Material m) {
		GameObject[] walls = GameObject.FindGameObjectsWithTag ("Wall");
		for (int i = 0; i < walls.Length; i++) {
			walls[i].renderer.material = m;
		}
	}

	void SpawnFalseEnemy() {
		int random = Random.Range (0, 100);
		if (random < 20) {
			RaycastHit hit;
			if (!Physics.Raycast (player.position, player.forward.normalized, out hit, 5)) {
				Instantiate (falseEnemy, player.position + 5 * (player.forward.normalized), player.rotation);
				falseEnemySpawned = true;
			}
		}
	}

	void SetLightColor(Color c) {
		for (int i = 0; i < lights.Length; i++) {
			lights[i].light.color = c;
		}
	}
}
