using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void OnGUI()
	{
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(Screen.width/2-350,Screen.height/2 + 100,120,50), "Start New Game")) {
			newGameSetUP();
			Application.LoadLevel("OpeningScene");
		}
		
		// Make the second button.
		if (PlayerPrefs.GetInt ("GameExist", 0) == 1) 
		{
			if (GUI.Button (new Rect(Screen.width/2-200, Screen.height/2 + 100, 120, 50), "Continue Game")) {
				Application.LoadLevel (PlayerPrefs.GetString ("LastKnownLevel"));
			}
		}
		else {
			GUI.Button (new Rect(Screen.width/2-200, Screen.height/2 + 100, 120, 50), "Continue Game");
		}
		
		if(GUI.Button(new Rect(Screen.width/2 + 100,Screen.height/2 + 100,120,50), "Game Credits")) {
			Application.LoadLevel("GameCredits");
		}
		
		if(GUI.Button(new Rect(Screen.width/2 + 250,Screen.height/2 + 100,120,50), "Quit Game")) {
			Application.Quit();
		}
		
	}
	
	void newGameSetUP()
	{
		//Clean all the PlayerPrefs
		PlayerPrefs.DeleteAll ();
		//Set all the PlayerPrefs to their default value
		PlayerPrefs.SetInt ("GameStarted", 0);
		PlayerPrefs.SetInt ("GameExists", 0);
		PlayerPrefs.SetInt("bloodNoteFound",0);
		PlayerPrefs.SetInt("policeNoteFound",0);
		PlayerPrefs.SetInt ("villageEmptyFound",0);
		PlayerPrefs.SetInt("knifeBloodFound",0);
		PlayerPrefs.GetInt("priestRobesFound",0);
		PlayerPrefs.SetInt("photographPriestFound",0);
		PlayerPrefs.SetInt("journalDarknessFound",0);
		PlayerPrefs.SetInt("journalPeopleFound",0);
		PlayerPrefs.SetInt("journalFinalPieceFound",0);
		PlayerPrefs.SetInt("letterFound",1);
		PlayerPrefs.SetInt("villageDisappearedKnown",0);
		PlayerPrefs.SetInt("murderedVillagersKnown",0);
		PlayerPrefs.SetInt("knifeIsPriestKnown",0);
		PlayerPrefs.SetInt("priestIsMurdererKnown",0);
		PlayerPrefs.SetInt("priestIsShadyKnown",0);
		PlayerPrefs.SetInt("townSacrificKnown",0);
		PlayerPrefs.SetInt("oneMoreRequiredKnown",0);
		PlayerPrefs.SetInt("priestTrappingPersonKnown",0);
		PlayerPrefs.SetInt("FinalSacificKnown",0);
		PlayerPrefs.SetFloat("SanityLevel", 100f);
		PlayerPrefs.SetFloat("MaxSanityLevel",100f);
		PlayerPrefs.SetString("LastKnownLevel", "villageScene");
	}
}

