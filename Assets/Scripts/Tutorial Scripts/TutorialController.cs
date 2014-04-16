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
	public Texture tutorialFinished;
	public TutorialStepTrigger st;


	// Use this for initialization
	void Start () 
	{
		if (PlayerPrefs.GetInt ("GameStarted", 0) == 1) 
		{
			DestroyObject (GameObject.FindWithTag ("TutorialBoundary"));
			DestroyObject (GameObject.FindWithTag ("TutorialTrigger"));
			DestroyObject (GameObject.FindWithTag ("TutorialItem"));
			DestroyObject (GameObject.FindWithTag ("TutorialEndBoundary"));
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

	}

	void OnGUI()
	{
		if (taskIsComplete) 
		{
			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), taskComplete)) 
			{
					st.canMoveOn = true;
					taskIsComplete = false;
			}
		}

		if (!initalTuorialDone) 
		{
			//Display prompt
			GUI.Box (new Rect(Screen.width-Screen.width/3-150,Screen.height-Screen.height/3-150,300,175), moveKeyPrompt);
		} 
		else if (!sprintTutorialDone) 
		{
			if(GUI.Button (new Rect(Screen.width-Screen.width/3-150,Screen.height-Screen.height/3-150,300,300), sprintPrompt))
			{
				if(GUI.Button (new Rect(Screen.width-Screen.width/3-150,Screen.height-Screen.height/3-150,300,300), staminaBarExample))
				{
					GUI.Box (new Rect(Screen.width-Screen.width/3-150,Screen.height-Screen.height/3-150,300,300), sprintPrompt2);
				}
			}
		} 
		else if (!clueTutorialDone) 
		{
			if(GUI.Button (new Rect(Screen.width-Screen.width/3-150,Screen.height-Screen.height/3-150,300,300), cluePrompt))
			{
				GUI.Box (new Rect(Screen.width-Screen.width/3-150,Screen.height-Screen.height/3-150,300,300), cluePrompt2);
			}
		} 
		else if (!menuTutorialDone) 
		{
			GUI.Box (new Rect(Screen.width-Screen.width/3-150,Screen.height-Screen.height/3-150,300,300), openMenuPrompt);
		} 
		else if (!monsterSanTutorialDone) 
		{
			GUI.Box (new Rect(Screen.width-Screen.width/3-150,Screen.height-Screen.height/3-150,300,300), combineCluePrompt);
		} 
		else if (!tutorialComplete) 
		{
			GUI.Box (new Rect(Screen.width-Screen.width/3-150,Screen.height-Screen.height/3-150,300,300), shrinePrompt);
		} 
		else if (tutorialComplete) 
		{
			bool temp = true;
			if(temp)
			{
				if(GUI.Button(new Rect(Screen.width-Screen.width/3-150,Screen.height-Screen.height/3-150,300,300), tutorialFinished))
				{
					temp = false;
				}
			}
		}
	}
	
}
