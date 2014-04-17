using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {


	public bool canEnter = false;	
	public SanityBarController sbc;
	public ItemMenu im;
	public string levelToSwitch;
	public Texture doorCommand;
	private Transform player;
	
	void Start() 
	{
		sbc = GameObject.FindGameObjectWithTag("GameController").GetComponent<SanityBarController> ();
		im = GameObject.FindGameObjectWithTag("ItemMenu").GetComponent<ItemMenu> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	// Update is called once per frame
	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {
			canEnter = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			canEnter = false;
		}
	}

	void Update() {

		if (canEnter && Input.GetKeyDown (KeyCode.E)) {
			im.saveClues();
			sbc.saveSanity();
			PlayerPrefs.SetString("LastKnownLevel", levelToSwitch);
			if (!levelToSwitch.Equals("villageScene")) {
				PlayerInitialPlacementController.lastKnownPlayerPosition = new Vector3(player.position.x, player.position.y, player.position.z);
				PlayerInitialPlacementController.lastKnownPlayerRotation = new Quaternion(player.rotation.x, player.rotation.y, player.rotation.z, player.rotation.w);
				PlayerInitialPlacementController.movePlayer = false;
			}
			else {
				PlayerInitialPlacementController.movePlayer = true;
			}
			Application.LoadLevel(levelToSwitch);
		}
	}
	void OnGUI()
	{
		if (canEnter) 
		{
			GUI.Label (new Rect (Screen.width-Screen.width/3, 10,300,150), doorCommand);
		}
	}

}
