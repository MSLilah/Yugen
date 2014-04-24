using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {
	
	
	public bool canPickUp;	
	public ItemMenu im;
	public int clueIdentity;
	private bool itemachieved;
	public Texture clueCommand;
	public string objectKey;
	private GameObject[] enemies;
	private SanityBarController sbc;
	
	void Start() 
	{
		if (PlayerPrefs.GetInt (objectKey) == 1) 
		{
			Destroy(this.gameObject);
		}
		sbc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<SanityBarController> ();
		im = GameObject.FindGameObjectWithTag("ItemMenu").GetComponent<ItemMenu> ();
		canPickUp = false;
		itemachieved = false;
		if (GameObject.FindGameObjectsWithTag("Clue").Length > 0) {
			enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			EnableEnemies (false);
		}
	}
	// Update is called once per frame
	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {
			canPickUp = true;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			canPickUp = false;
		}
	}
	
	void Update() {
		if (canPickUp && Input.GetKeyDown (KeyCode.E)) {
			itemachieved = true;
			im.pickedUpClue = clueIdentity;
			im.newClueFound = true;
			sbc.maxSanity -= 7;
			Destroy(this.gameObject);
			EnableEnemies(true);
		}
	}
	void OnGUI()
	{
		if (canPickUp && !itemachieved) 
		{
			GUI.Label (new Rect (Screen.width-Screen.width/3, 10,300,150), clueCommand);
		}
	}

	void EnableEnemies(bool active) {
		for (int i = 0; i < enemies.Length; i++) {
			enemies[i].SetActive(active);
		}
	}
	
}
