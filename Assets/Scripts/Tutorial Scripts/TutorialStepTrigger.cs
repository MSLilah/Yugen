using UnityEngine;
using System.Collections;

public class TutorialStepTrigger : MonoBehaviour {
	public string stepName;
	public bool displayWarning;
	public TutorialController tu;
	public float playerInitXPos = 554.9058f;
	public float playerInitYPos = 10f;
	public float playerInitZPos = 339.2068f;
	public float playerInitYRotation = -86.88f;

	public Texture sprintWarning;
	public Texture clueWarning;
	public Texture menuWarning;
	public Texture combineWarning;
	public Texture shrineWarning;

	// Use this for initialization
	void Start () 
	{
		tu = GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialController> ();
	}
	
	// Update is called once per frame
	void Update () {	
	}

	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") 
		{
			if(tu.canMoveOn)
			{
				if(stepName.Equals("SprintStart"))
				{
					tu.initalTuorialDone = true;
					tu.canMoveOn = false;
					Destroy(this.gameObject);
				}
				else if(stepName.Equals("SprintEnd"))
				{
					tu.sprintTutorialDone = true;
					tu.canMoveOn = false;
					tu.done = false;
					Destroy(this.gameObject);
				}
				else if(stepName.Equals("ClueEnd"))
				{
					tu.clueTutorialDone = true;
					tu.canMoveOn = false;
					tu.done = false;
					Destroy(this.gameObject);
				}
				else if(stepName.Equals("MenuEnd"))
				{
					tu.menuTutorialDone = true;
					tu.canMoveOn = false;
					tu.done = false;
					Destroy(this.gameObject);
				}
				else if(stepName.Equals("MonsterEnd"))
				{
					tu.monsterSanTutorialDone = true;
					tu.canMoveOn = false;
					tu.done = false;
					tu.taskIsComplete = false;
					MouseLook.noPrompt = true;
					Destroy(this.gameObject);
				}
				else if(stepName.Equals("ShrineEnd"))
				{
					tu.tutorialComplete = true;
					tu.canMoveOn = true;
					tu.done = false;
					Destroy(this.gameObject);
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
				GUI.Label (new Rect (Screen.width-Screen.width/3, 10,300,150),  sprintWarning);
			}
			else if (!tu.clueTutorialDone && stepName.Equals("ClueEnd"))
			{
				GUI.Label (new Rect (Screen.width-Screen.width/3, 10,300,150),  clueWarning);
			}
			else if (!tu.menuTutorialDone && stepName.Equals("MenuEnd"))
			{
				GUI.Label (new Rect (Screen.width-Screen.width/3, 10,300,150),  menuWarning);
			}
			else if (!tu.monsterSanTutorialDone && stepName.Equals("MonsterEnd"))
			{
				GUI.Label (new Rect (Screen.width-Screen.width/3, 10,300,150),  combineWarning);
			}
			else if(!tu.tutorialComplete && stepName.Equals("ShrineEnd"))
			{
				GUI.Label (new Rect (Screen.width-Screen.width/3, 10,300,150),  shrineWarning);
			}
		}
	}

}
