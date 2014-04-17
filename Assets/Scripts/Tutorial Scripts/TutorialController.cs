using UnityEngine;
using System.Collections;

public class TutorialController : MonoBehaviour {
	public bool initalTuorialDone;
	public bool sprintTutorialDone;
	public bool clueTutorialDone;
	public bool menuTutorialDone;
	public bool monsterSanTutorialDone;
	public bool tutorialComplete;
	public bool enteredVillage;
	public bool taskIsComplete;
	public bool canMoveOn;
	public bool finalPrompt;
	public bool nextPrompt;
	public bool done;

	//Textures used for the tutorial:
	public Texture taskComplete;
	public Texture moveKeyPrompt;
	public Texture sprintPrompt;
	public Texture sprintPrompt2;
	public Texture staminaBarExample;
	public Texture cluePrompt;
	public Texture cluePrompt2;
	public Texture openMenuPrompt;
	public Texture combineCluePrompt;
	public Texture shrinePrompt;
	public TutorialStepTrigger st;
	public float playerInitXPos = 554.9058f;
	public float playerInitYPos = 10f;
	public float playerInitZPos = 339.2068f;
	public float playerInitYRotation = -86.88f;
	public float tutorialPlayerInitXPos = 581.7026f;
	public float tutorialPlayerInitYPos = 10f;
	public float tutorialPlayerInitZPos = 107.9105f;
	public float tutorialPlayerInitYRotation = -316.1f;


	// Use this for initialization
	void Start () 
	{
		//PlayerPrefs.SetInt ("GameStarted", 0);
		if (PlayerPrefs.GetInt ("GameStarted", 0) == 1) 
		{
			DestroyObject (GameObject.FindWithTag ("TutorialBoundary"));
			DestroyObject (GameObject.FindWithTag ("TutorialTrigger"));
			DestroyObject (GameObject.FindWithTag ("TutorialItem"));
			DestroyObject (GameObject.FindWithTag ("TutorialEndBoundary"));
			DestroyObject (GameObject.FindWithTag ("TutorialMenu"));
			DestroyObject (GameObject.FindWithTag ("Tutorial"));
		}
		else 
		{
			initalTuorialDone = false;
			sprintTutorialDone = false;
			clueTutorialDone = false;
			menuTutorialDone = false;
			monsterSanTutorialDone = false;
			tutorialComplete = false;
			enteredVillage = false;
			canMoveOn = true;
			nextPrompt = false;
			finalPrompt = false;
			done = false;
			st = GameObject.FindGameObjectWithTag("TutorialTrigger").GetComponent<TutorialStepTrigger> ();
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt("GameStarted",0) == 1)
		{
			DestroyObject(GameObject.FindWithTag("TutorialBoundary"));
			DestroyObject(GameObject.FindWithTag("TutorialTrigger"));
			DestroyObject(GameObject.FindWithTag("TutorialItem"));
			DestroyObject(GameObject.FindWithTag("TutorialEndBoundary"));
		}

		if (finalPrompt && Input.GetKey ("left shift") && (Input.GetKey ("w") || Input.GetKey ("up"))) 
		{
			taskIsComplete = true;
		}
	}


	void OnGUI()
	{
		if (taskIsComplete) 
		{
			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 100), taskComplete)) 
			{
				canMoveOn = true;
				taskIsComplete = false;
				finalPrompt = false;
				nextPrompt = false;
				done = true;
			}
		}

		if (!initalTuorialDone) 
		{
			//Display prompt
			GUI.Box (new Rect(Screen.width-Screen.width/3,Screen.height-Screen.height/4,300,140), moveKeyPrompt);
		} 
		else if (!sprintTutorialDone) 
		{
			if(!done)
			{
				if(!nextPrompt)
				{
					GUI.Box(new Rect(Screen.width-Screen.width/3,Screen.height-Screen.height/3,300,140), sprintPrompt);
					if(GUI.Button(new Rect(Screen.width-Screen.width/3+90,Screen.height-Screen.height/3+150,120,50), "Next Prompt"))
					{
						nextPrompt = true;
					}
				}
				if(nextPrompt && !finalPrompt)
				{
					GUI.Box(new Rect(Screen.width-Screen.width/3,Screen.height-Screen.height/3,300,140), staminaBarExample);
					if(GUI.Button(new Rect(Screen.width-Screen.width/3+90,Screen.height-Screen.height/3+150,120,50), "Next Prompt"))
					{
						finalPrompt = true;
					}
				}
				if(finalPrompt && !taskIsComplete)
				{
					GUI.Box(new Rect(Screen.width-Screen.width/3,Screen.height-Screen.height/3,300,140), sprintPrompt2);
				}
			}
		} 
		else if (!clueTutorialDone) 
		{
			if(!done)
			{
				if(!nextPrompt)
				{
					GUI.Box(new Rect(Screen.width-Screen.width/3,Screen.height-Screen.height/3,300,140), cluePrompt);
					if(GUI.Button(new Rect(Screen.width-Screen.width/3+90,Screen.height-Screen.height/3+150,120,50), "Next Prompt"))
					{
						nextPrompt = true;
					}
				}
				if(nextPrompt && !taskIsComplete)
				{
					GUI.Box(new Rect(Screen.width-Screen.width/3,Screen.height-Screen.height/3,300,140), cluePrompt2);
				}
			}
		} 
		else if (!menuTutorialDone) 
		{
			if(!done)
			{
				GUI.Box(new Rect(Screen.width-Screen.width/3,Screen.height-Screen.height/3,300,140), openMenuPrompt);
			}
		} 
		else if (!monsterSanTutorialDone) 
		{
			if(!done)
			{
				GUI.Box(new Rect(Screen.width-Screen.width/3,Screen.height-Screen.height/3, 290, 290), combineCluePrompt);
			}
		} 
		else if (!tutorialComplete) 
		{
			if(!done)
			{
				GUI.Box(new Rect(Screen.width-Screen.width/3,Screen.height-Screen.height/3,300,140), shrinePrompt);
			}
		} 
	}

}
