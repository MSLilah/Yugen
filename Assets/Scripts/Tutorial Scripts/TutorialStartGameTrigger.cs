using UnityEngine;
using System.Collections;

public class TutorialStartGameTrigger : MonoBehaviour {
	public bool displayMessage;
	public bool gameOn = false;
	public Texture startGame;
	public TutorialController tu;
	public TutorialStepTrigger tst;
	private Transform player;
	public float playerInitXPos = 554.9058f;
	public float playerInitYPos = 10f;
	public float playerInitZPos = 339.2068f;
	public float playerInitYRotation = -86.88f;
	
	// Use this for initialization
	void Start () 
	{
		tu = GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialController> ();
		tst = GameObject.FindGameObjectWithTag("TutorialTrigger").GetComponent<TutorialStepTrigger> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
			
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") 
		{
			if(tu.tutorialComplete)
			{
				displayMessage = true;
			}
		}
		
	}
	
	void OnTriggerExit(Collider other)
	{
		displayMessage = false;
	}
	
	void OnGUI()
	{
		if(displayMessage)
		{
			if(tu.tutorialComplete)
			{
				GUI.Label(new Rect(Screen.width/2,Screen.height/2, 300,150), startGame);
				if(GUI.Button(new Rect(Screen.width/2+75,Screen.height/2+150, 100,50), "Enter Village"))
				{
					print ("The player will now move");
					PlayerInitialPlacementController.lastKnownPlayerPosition = new Vector3(playerInitXPos, playerInitYPos, playerInitZPos);
					PlayerInitialPlacementController.lastKnownPlayerRotation = new Quaternion(0.0f, playerInitYRotation, 0.0f, 0.0f);
					PlayerInitialPlacementController.movePlayer = true;
					PlayerPrefs.SetInt("GameStarted", 1);
					Application.LoadLevel("villageScene");
				}
			}
		}
	}
}
