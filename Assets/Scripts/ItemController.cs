using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {
	
	
	public bool canPickUp = false;	
	public ItemMenu im;
	public int clueIdentity;
	public string name;
	private bool itemachieved = false;
	
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
		if (itemachieved) 
		{
			print("I can destroymyself");
			print(name);
			Destroy(GameObject.Find (name));
		}
	}
	
	void Update() {
		if (canPickUp && Input.GetKeyDown (KeyCode.E)) {
			itemachieved = true;
			im.pickedUpClue = clueIdentity;
			im.newClueFound = true;
		}
	}
	void OnGUI()
	{
		if (canPickUp && !itemachieved) 
		{
			GUI.Label(new Rect(Screen.width/2-100,Screen.height/2-100,200,200),"Press E to Pick Up Clue");
		}
	}
	
}
