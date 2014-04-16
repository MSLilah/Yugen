using UnityEngine;
using System.Collections;

public class TutorialStepTrigger : MonoBehaviour {
	public string stepName;
	public bool canMoveOn;
	public bool displayWarning;
	TutorialController tu;

	// Use this for initialization
	void Start () 
	{
		canMoveOn = true;
		tu = GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") 
		{
			if(canMoveOn)
			{
				if(stepName.Equals("SprintStart"))
				{
					print ("I got here");
					tu.initalTuorialDone = true;
					canMoveOn = false;
					gameObject.collider.isTrigger = true;
				}
				else if(stepName.Equals("SprintEnd"))
				{
					tu.sprintTutorialDone = true;
					canMoveOn = false;
					Destroy(this.collider);
					Destroy(this);
				}
				else if(stepName.Equals("ClueEnd"))
				{
					tu.clueTutorialDone = true;
					canMoveOn = false;
					Destroy(this.collider);
					Destroy(this);
				}
				else if(stepName.Equals("MenuEnd"))
				{
					tu.menuTutorialDone = true;
					canMoveOn = false;
					Destroy(this.collider);
					Destroy(this);
				}
				else if(stepName.Equals("MonsterEnd"))
				{
					tu.monsterSanTutorialDone = true;
					canMoveOn = false;
					Destroy(this);
				}
				else if(stepName.Equals("ShrineEnd"))
				{
					tu.tutorialComplete = true;
					canMoveOn = true;
					Destroy(this);
				}
			}
		}

	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			if (!tu.sprintTutorialDone && stepName.Equals("SprintEnd"))
			{
				displayWarning = true;
			}
			else if (!tu.clueTutorialDone && stepName.Equals("ClueEnd"))
			{
				displayWarning = true;
			}
			else if (!tu.menuTutorialDone && stepName.Equals("MenuEnd"))
			{
				displayWarning = true;
			}
			else if (!tu.monsterSanTutorialDone && stepName.Equals("MonsterEnd"))
			{
				displayWarning = true;
			}
			else if(!tu.tutorialComplete && stepName.Equals("ShrineEnd"))
			{
				displayWarning = true;
			}
			else
			{
				displayWarning = false;
			}

		}
	}
	void OnTriggerExit(Collider other)
	{
		displayWarning = false;
	}

	void OnGUI()
	{
		if(displayWarning)
		{
			if (!tu.sprintTutorialDone && stepName.Equals("SprintEnd"))
			{
				GUI.Label(new Rect(Screen.width/2-250,Screen.height/2 - 500, 300,300), "Sorry, you aren't ready to move on, why don't you practice sprinting?");
			}
			else if (!tu.clueTutorialDone && stepName.Equals("ClueEnd"))
			{
				GUI.Label(new Rect(Screen.width/2-250,Screen.height/2 - 150, 500,300), "Sorry, you aren't ready to move on, why don't you try to pick up the Clues");
			}
			else if (!tu.menuTutorialDone && stepName.Equals("MenuEnd"))
			{
				GUI.Label(new Rect(Screen.width/2-250,Screen.height/2 - 150, 500,300), "Sorry, you aren't ready to move on, why don't you look at your inventory?");
			}
			else if (!tu.monsterSanTutorialDone && stepName.Equals("MonsterEnd"))
			{
				GUI.Label(new Rect(Screen.width/2-250,Screen.height/2 - 150, 300,500), "Sorry, you aren't ready to move on, why don't you attempted to combine clues?");
			}
			else if(!tu.tutorialComplete && stepName.Equals("ShrineEnd"))
			{
				GUI.Label(new Rect(Screen.width/2-250,Screen.height/2 - 150, 300,500), "Sorry, you aren't ready to enter the Village yet, why don't you pray at the Shrine?");
			}
		}
	}

}
