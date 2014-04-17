using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {
	
	
	public bool canPickUp = false;	
	public ItemMenu im;
	public int clueIdentity;
	private bool itemachieved = false;
	public Texture clueCommand;
	
	void Start() 
	{
		im = GameObject.FindGameObjectWithTag("ItemMenu").GetComponent<ItemMenu> ();
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
			Destroy(this.gameObject);
		}
	}
	void OnGUI()
	{
		if (canPickUp && !itemachieved) 
		{
			GUI.Label (new Rect (Screen.width-Screen.width/3, 10,300,150), clueCommand);
		}
	}
	
}
