using UnityEngine;
using System.Collections;



public class ItemMenu : MonoBehaviour {

	public bool menuOpen = false;
	public bool canNotSeeClues = false;
	public bool newClueFound = false;
	public int pickedUpClue = -1;
	private bool attempt = false;
	public string currentLevel;
	public SanityBarController sbc;
	public GameCompletionController gcc;
	//these are the booleans for the clues that can be found
	public bool bloodNoteFound;
	public bool policeNoteFound;
	public bool villageEmptyFound;
	public bool knifeBloodFound;
	public bool priestRobesFound;
	public bool photographPriestFound;
	public bool journalDarknessFound;
	public bool journalPeopleFound;
	public bool journalFinalPieceFound;
	public bool letterFound;

	//These are the booleans for the combined items
	public bool villageDisappearedKnown;
	public bool murderedVillagersKnown;
	public bool knifeIsPriestKnown;
	public bool priestIsMurdererKnown;
	public bool priestIsShadyKnown;
	public bool townSacrificKnown;
	public bool oneMoreRequiredKnown;
	public bool priestTrappingPersonKnown;
	public bool FinalSacrificKnown;

	
	//These are the booleans that help combine two items
	public static bool twoItemsSelected = false;
	public static bool combined1 = false;
	public static bool combined2 = false;

	//These are the Textures for the clues
	public Texture bloodNote;
	public Texture policeNote;
	public Texture villageEmpty;
	public Texture knifeBlood;
	public Texture priestRobes;
	public Texture photographPriest;
	public Texture knifeIsPriest;
	public Texture journalDarkness;
	public Texture journalPeople;
	public Texture journalFinalPiece;
	public Texture letter;
	public Texture letterWords;
	public Texture villageDisappeared;
	public Texture murderedVillagers;
	public Texture priestIsMurderer;
	public Texture priestIsShady;
	public Texture townSacrific;
	public Texture oneMoreRequired;
	public Texture priestTrappingPerson;
	public Texture FinalSacrific;

	//These are constants that will help know what is items are selected
	//Letter to the MadMan give at start
	public const int LETTER = 0;
	//A note Written in Blood
	public const int BLOOD = 1;
	//Police memo
	public const int POLICE = 2;
	//The village is empty
	public const int EMPTY = 3;
	//bloody robes
	public const int ROBES = 4;
	//bloody knife
	public const int BKNIFE = 5;
	//Photography of priest at the altar
	public const int PHOTO = 6;
	public const int PKNIFE = 7;
	//Journal Entry #1  
	public const int DARK = 8;
	//Journal Entry #2 
	public const int PEOPLE = 9;
	//Journal Entry #3 
	public const int FPIECE = 10;
	public const int DISAPPEARED = 12;
	public const int MURDEREDV = 13;
	public const int PMURDERER = 14;
	public const int SHADY = 15;
	public const int SACRIFIC = 16;
	public const int MORE = 17;
	public const int TRAP = 18;
	public const int FINAL = 19;

	private int selectOne = -1;
	private int selectTwo = -1;
	private int combineID = -1;


	//This is the information that will be displayed for the clues
	//##TODO## For some clues it might look better to display images instead of text
	private const string bloodNoteInfo = "There is a faded note written in blood. You can barely make out what it says. It reads \"Help me\"";
	private const string policeNoteInfo = "We’ve been getting reports of some of the villagers going missing.  The strange thing, though, is that they’re disappearing  without any traces.  All the missing people were normal and well-adjusted, and there were no signs given  to family members that something may have been wrong.  We also haven’t been able to find any signs or indications that they were kidnapped.  They seem to have disappeared out of thin air.  In a village this small, we should be able to find at least something.  ";
	private const string villageEmptyInfo = "Hmmm...there doesn't seem to be anyone in the village. ";
	private const string priestRobesInfo = "These seem to be the robes of a Shinto priest.  They are stained with blood. ";
	private const string bloodKnifeInfo = "You find a strange, uniquely-shaped knife.  The blade is stained with blood.  ";
	private const string photographPriestInfo = "You see a photograph of a Shinto priest in a shrine. There are a number of things hung on the wall, including a strange, uniquely-shaped knife. ";
	private const string knifeIsPriestInfo = "This is a very unique knife, and one with the exact same shape can be seen hanging on the wall in this photograph. This knife must belong to the high priest.  ";
	private const string journalDarknessInfo = "The day is coming. The prophesied day of arrival.  The day the darkness will come and consume the village. I must prepare the way for the darkness, its path to our world.  The prophesied day must come without interference.  ";
	private const string journalPeopleInfo = "One more piece is required. One with terrible knowledge, one who has come to a terrible realization about the way of the universe, one who knows what is coming.  That is the final piece, and that is what is missing.  Until this piece is found, the way can only ever be partially opened.  ";
	private const string journalFinalPieceInfo = "The pieces are in place, and the final events have been set into motion. The final piece has been summoned.  She cannot escape her destiny. Soon she will arrive, and the way will be prepared.  The day of prophesy is nearly upon us.";
	private const string letterInfo = "Dear Madman,  ";
	private const string villageDisappearedInfo = "Based off of this information, it seems a number of villagers were going missing.  It seems likely that this trend continued, and somehow all the villagers ended up disappearing.  ";
	private const string murderedVillagersInfo = "This note written in blood indicates that someone was probably murdered.  Since all the villagers have disappeared, it seems possible that someone murdered the villagers.  ";
	private const string priestIsMurdererInfo = "The likely murder of the villagers, combined with the evidence on the priest’s robe and knife,  indicates that the high priest was responsible for the deaths of the villagers.  ";
	private const string priestIsShadyInfo = "The blood on the knife and the robes indicates that the priest was probably involved in something.  Did he commit murder? Or did someone murder him?  ";
	private const string townSacrificInfo = "If the high priest murdered everyone in the village, then it seems likely that that  was his way of \"preparing the way for the darkness\", and that the village was meant as a sacrifice.  ";
	private const string oneMoreRequiredInfo = "Clearly, the ritual remains incomplete.  One more \"piece\" is required, likely another sacrifice.  The way is only partially opened? Does that explain these creatures?  ";
	private const string priestTrappingPersonInfo = "Clearly, the Priest attempted to summon the final piece to the village to complete  the ritual and pave the way for this \"darkness\".  If these creatures are what has already come through,  what would happen if the ritual were to be brought to its completion? I shudder to think.  ";
	private const string FinalSacrificInfo = "GAME OVER";


	//These strings are used to display the messages in the menu
	private string itemSelectedOne = null;
	private string itemSelectedTwo = null;
	private string combinedMessage = null;
	private string attemptMessage = null;
	private int DisplayWidth = (Screen.width - 150) / 2;
	private int DisplayHeight = Screen.height - 300;


	// Use this for initialization
	void Start () 
	{
		sbc = GameObject.FindGameObjectWithTag("GameController").GetComponent<SanityBarController> ();
		gcc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameCompletionController> ();
		canNotSeeClues = false;
		PlayerPrefs.SetString("LastKnownScene", currentLevel);
		bloodNoteFound = setBooleanVariable(PlayerPrefs.GetInt("bloodNoteFound"));
		policeNoteFound = setBooleanVariable (PlayerPrefs.GetInt ("policeNoteFound"));
		villageEmptyFound = setBooleanVariable (PlayerPrefs.GetInt ("villageEmptyFound"));
		knifeBloodFound = setBooleanVariable (PlayerPrefs.GetInt ("knifeBloodFound"));
		priestRobesFound = setBooleanVariable(PlayerPrefs.GetInt("priestRobesFound"));
		photographPriestFound = setBooleanVariable(PlayerPrefs.GetInt("photographPriestFound"));
		journalDarknessFound = setBooleanVariable(PlayerPrefs.GetInt("journalDarknessFound"));
		journalPeopleFound = setBooleanVariable(PlayerPrefs.GetInt("journalPeopleFound"));
		journalFinalPieceFound = setBooleanVariable(PlayerPrefs.GetInt("journalFinalPieceFound"));
		letterFound = setBooleanVariable(PlayerPrefs.GetInt("letterFound"));
		villageDisappearedKnown = setBooleanVariable(PlayerPrefs.GetInt("villageDisappearedKnown"));
		murderedVillagersKnown = setBooleanVariable(PlayerPrefs.GetInt("murderedVillagersKnown"));
		knifeIsPriestKnown = setBooleanVariable(PlayerPrefs.GetInt("knifeIsPriestKnown"));
		priestIsMurdererKnown = setBooleanVariable(PlayerPrefs.GetInt("priestIsMurdererKnown"));
		priestIsShadyKnown = setBooleanVariable(PlayerPrefs.GetInt("priestIsShadyKnown"));
		townSacrificKnown = setBooleanVariable(PlayerPrefs.GetInt("townSacrificKnown"));
		oneMoreRequiredKnown = setBooleanVariable(PlayerPrefs.GetInt("oneMoreRequiredKnown"));
		priestTrappingPersonKnown = setBooleanVariable(PlayerPrefs.GetInt("priestTrappingPersonKnown"));
		FinalSacrificKnown = setBooleanVariable(PlayerPrefs.GetInt("FinalSacificKnown"));
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("GameStarted",0) == 1)
		{
			if(Input.GetKeyDown("q"))
			{
				MouseLook.noPrompt = !(MouseLook.noPrompt);
				newClueFound = false;
				menuOpen = !menuOpen;
				clearSelectedItems();
			}
		}
		if(Input.GetKeyDown("w")) 
		{
			newClueFound = false;
		}

	}
	

	void OnGUI()
	{ 
		if(PlayerPrefs.GetInt("GameStarted",0) == 1)
		{
			if (pickedUpClue != -1) 
			{
				clueAchieved(pickedUpClue);
			}
			if (menuOpen) 
			{
				// Make the second button.
				if (GUI.Button (new Rect (10, 130, 120, 50), "Save Game")) {
						clearSelectedItems();
						saveClues();
						sbc.saveSanity();
						attempt = true;
						attemptMessage = "Game Saved!";
						PlayerPrefs.SetString("LastKnownLevel", currentLevel);
				}
				if(!canNotSeeClues)
				{
					if (GUI.Button (new Rect (10, 190, 120, 50), "Main Menu")) {
						Application.LoadLevel("Main Menu");
					}
				}
				
				if (GUI.Button (new Rect (10, 250, 120, 50), "Quit Game")) {
						Application.Quit();
				}
				if(!canNotSeeClues)
				{
					// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
					if (GUI.Button (new Rect (10, 70, 120, 50), "Clear Selected")) {
						clearSelectedItems();
					}

					if(letterFound)
					{
						if(!FinalSacrificKnown)
						{
							if(GUI.Button(new Rect(150, 70, 120, 100), letter))
							{
								changedSelectedItem(LETTER, letterInfo);
							}
						}
						else
						{
							GUI.Button(new Rect(150, 70, 120, 100), "Item Used");
						}
					}
					else
					{
						GUI.Button(new Rect(150, 70, 120, 100), "Empty");
					}

					if(bloodNoteFound || murderedVillagersKnown)
					{
						if(!murderedVillagersKnown)
						{
							if(GUI.Button(new Rect(280, 70, 120, 100), bloodNote))
							{
								changedSelectedItem(BLOOD, bloodNoteInfo);
							}
						}
						else if(!priestIsMurdererKnown)
						{
							if(GUI.Button(new Rect(280, 70, 120, 100), murderedVillagers))
							{
								changedSelectedItem(MURDEREDV, murderedVillagersInfo);
							}
						}
						else if(!townSacrificKnown)
						{
							if(GUI.Button(new Rect(280, 70, 120, 100), priestIsMurderer))
							{
								changedSelectedItem(PMURDERER, priestIsMurdererInfo);
							}
						}
						else
						{
							GUI.Button(new Rect(280, 70, 120, 100), "Item Used");
						}

					}
					else
					{
						GUI.Button(new Rect(280, 70, 120, 100), "Empty");
					}

					if(policeNoteFound || villageDisappearedKnown)
					{
						if(!villageDisappearedKnown)
						{
							if(GUI.Button(new Rect(410, 70, 120, 100), policeNote))
							{
								changedSelectedItem(POLICE, policeNoteInfo);
							}
						}
						else if(!murderedVillagersKnown)
						{
							if(GUI.Button(new Rect(410, 70, 120, 100), villageDisappeared))
							{
								changedSelectedItem(DISAPPEARED, villageDisappearedInfo);
							}
						}
						else
						{
							GUI.Button(new Rect(410, 70, 120, 100), "Item Used");
						}
					}
					else
					{
						GUI.Button(new Rect(410, 70, 120, 100), "Empty");
					}

					if(villageEmptyFound || villageDisappearedKnown)
					{
						if(!villageDisappearedKnown)
						{
							if(GUI.Button(new Rect(540, 70, 120, 100), villageEmpty))
							{
								changedSelectedItem(EMPTY, villageEmptyInfo);
							}
						}
						else				
						{
							GUI.Button(new Rect(540, 70, 120, 100), "Item Used");
						}
					}
					else
					{
						GUI.Button(new Rect(540, 70, 120, 100), "Empty");
					}

					if(knifeBloodFound || knifeIsPriestKnown)
					{
						if(!knifeIsPriestKnown)
						{
							if(GUI.Button(new Rect(670, 70, 120, 100), knifeBlood))
							{
								changedSelectedItem(BKNIFE, bloodKnifeInfo);
							}
						}
						else if(!priestIsShadyKnown)
						{
							if(GUI.Button(new Rect(670, 70, 120, 100), knifeIsPriest))
							{
								changedSelectedItem(PKNIFE, knifeIsPriestInfo);
							}
						}
						else
						{
							GUI.Button(new Rect(670, 70, 120, 100), "Item Used");
						}
					}
					else
					{
						GUI.Button(new Rect(670, 70, 120, 100), "Empty");
					}

					////Start the Second Row of buttons

					if(priestRobesFound || priestIsShadyKnown)
					{
						if(!priestIsShadyKnown)
						{
							if(GUI.Button(new Rect(150, 180, 120, 100), priestRobes))
							{
								changedSelectedItem(ROBES, priestRobesInfo);
							}
						}
						else if(!priestIsMurdererKnown)
						{
							if(GUI.Button(new Rect(150, 180, 120, 100), priestIsShady))
							{
								changedSelectedItem(SHADY, priestIsShadyInfo);
							}
						}
						else
						{
							GUI.Button(new Rect(150, 180, 120, 100), "Item Used");
						}
					}
					else
					{
						GUI.Button(new Rect(150, 180, 120, 100), "Empty");
					}

					if(photographPriestFound || knifeIsPriestKnown)
					{
						if(!knifeIsPriestKnown)
						{
							if(GUI.Button(new Rect(280, 180, 120, 100), photographPriest))
							{
								changedSelectedItem(PHOTO, photographPriestInfo);
							}
						}
						else if(knifeIsPriestKnown)
						{
							GUI.Button(new Rect(280, 180, 120, 100), "Item Used");
						}
					}
					else
					{
						GUI.Button(new Rect(280, 180, 120, 100), "Empty");
					}

					if(journalDarknessFound || townSacrificKnown)
					{
						if(!townSacrificKnown)
						{
							if(GUI.Button(new Rect(410, 180, 120, 100), journalDarkness))
							{
								changedSelectedItem(DARK, journalDarknessInfo);
							}
						}
						else if(!oneMoreRequiredKnown)
						{
							if(GUI.Button(new Rect(410, 180, 120, 100), townSacrific))
							{
								changedSelectedItem(SACRIFIC, townSacrificInfo);
							}
						}
						else if(!priestTrappingPersonKnown)
						{
							if(GUI.Button(new Rect(410, 180, 120, 100), oneMoreRequired))
							{
								changedSelectedItem(MORE, oneMoreRequiredInfo);
							}
						}
						else
						{
							GUI.Button(new Rect(410, 180, 120, 100), "Item Used");
						}
					}
					else
					{
						GUI.Button(new Rect(410, 180, 120, 100), "Empty");
					}

					if(journalPeopleFound || oneMoreRequiredKnown)
					{
						if(!oneMoreRequiredKnown)
						{
							if(GUI.Button(new Rect(540, 180, 120, 100), journalPeople))
							{
								changedSelectedItem(PEOPLE, journalPeopleInfo);
							}
						}
						else
						{
							GUI.Button(new Rect(540, 180, 120, 100), "Item Used");
						}
					}
					else
					{
						GUI.Button(new Rect(540, 180, 120, 100), "Empty");
					}

					if(journalFinalPieceFound || FinalSacrificKnown || priestTrappingPersonKnown)
					{
						if(!priestTrappingPersonKnown)
						{
							if(GUI.Button(new Rect(670, 180, 120, 100), journalFinalPiece))
							{
								changedSelectedItem(FPIECE, journalFinalPieceInfo);
							}
						}
						else if(!FinalSacrificKnown)
						{
							if(GUI.Button(new Rect(670, 180, 120, 100), priestTrappingPerson))
							{
								changedSelectedItem(TRAP, priestTrappingPersonInfo);
							}
						}
						else
						{
							if(GUI.Button(new Rect(670, 180, 120, 100), FinalSacrific))
							{
								changedSelectedItem(FINAL, FinalSacrificInfo);
							}
						}
					}
					else
					{
						GUI.Button(new Rect(670, 180, 120, 100), "Empty");
					}

					//Display the Selected Clues

					if(itemSelectedOne != null)
					{
						diplayClue(selectOne,1);
					}

					if(itemSelectedTwo != null)
					{
						diplayClue(selectTwo,2);
					}

					if(twoItemsSelected)
					{
						if(GUI.Button(new Rect(10+DisplayWidth+10,300,120,100),"Combine Items?"))
						{
							attempt = true;
							if(canItemsCombine())
							{
								clearSelectedItems();
								attemptMessage = "These things make more sense together!";
								newClueFound = true;
								MouseLook.noPrompt = !(MouseLook.noPrompt);
								menuOpen = false;
							}
							else
							{
								attemptMessage = "These items mean nothing together!";
							}
						}
						
					}

					if(attempt)
					{
						GUI.Label(new Rect(10+DisplayWidth+10,430,120,100),attemptMessage);
					}
				}
			}
		}
		
	}
	
	bool canItemsCombine()
	{
		//POLICE + EMPTY = DISAPPEAR
		if ((selectOne == POLICE || selectTwo == POLICE) && (selectOne == EMPTY || selectTwo == EMPTY)) 
		{
			clearSelectedItems();
			clueAchieved(DISAPPEARED);
			return true;
		}
		//DISAPPEAR + BLOOD = MURDEREDV
		else if((selectOne == BLOOD || selectTwo == BLOOD) && (selectOne == DISAPPEARED || selectTwo == DISAPPEARED))
		{
			clearSelectedItems();
			clueAchieved(MURDEREDV);
			return true;
		}
		//MURDEREDV + SHADY = PMURDERER
		else if((selectOne == MURDEREDV || selectTwo == MURDEREDV) && (selectOne == SHADY || selectTwo == SHADY))
		{
			clearSelectedItems();
			clueAchieved(PMURDERER);
			return true;
		}
		//BKNIFE + PHOTO = PKNIFE
		else if((selectOne == BKNIFE || selectTwo == BKNIFE) && (selectOne == PHOTO || selectTwo == PHOTO))
		{
			clearSelectedItems();
			clueAchieved(PKNIFE);
			return true;
		}
		//PKNIFE + ROBES = SHADY
		else if((selectOne == ROBES || selectTwo == ROBES) && (selectOne == PKNIFE || selectTwo == PKNIFE))
		{
			clearSelectedItems();
			clueAchieved(SHADY);
			return true;
		}
		//PMURDERER + DARK = SACRIFIC
		else if((selectOne == PMURDERER || selectTwo == PMURDERER) && (selectOne == DARK || selectTwo == DARK))
		{
			clearSelectedItems();
			clueAchieved(SACRIFIC);
			return true;
		}
		//SACRIFIC + PEOPLE = MORE
		else if((selectOne == PEOPLE || selectTwo == PEOPLE) && (selectOne == SACRIFIC || selectTwo == SACRIFIC))
		{
			clearSelectedItems();
			clueAchieved(MORE);
			return true;
		}
		//MORE + FPIECE = TRAP
		else if((selectOne == FPIECE || selectTwo == FPIECE) && (selectOne == MORE || selectTwo == MORE))
		{
			clearSelectedItems();
			clueAchieved(TRAP);
			return true;
		}
		//TRAP + LETTER = FINAL
		else if((selectOne == TRAP || selectTwo == TRAP) && (selectOne == LETTER || selectTwo == LETTER))
		{
			clearSelectedItems();
			clueAchieved(FINAL);
			return true;
		}
		return false;
	}

	void clearSelectedItems()
	{
		itemSelectedOne = null;
		itemSelectedTwo = null;
		twoItemsSelected = false;
		attempt = false;
		attemptMessage = null;
		combinedMessage = null;
		selectOne = -1;
		selectTwo = -1;
	}

	void changedSelectedItem(int itemNumber, string message)
	{
		attemptMessage = null;
		attempt = false;
		if(selectOne == itemNumber)
		{
			itemSelectedOne = null;
			selectOne = -1;
			twoItemsSelected = false;
		}
		else if(selectTwo == itemNumber)
		{
			itemSelectedTwo = null;
			selectTwo = -1;
			twoItemsSelected = false;
		}
		else if(selectOne == -1 && selectTwo != itemNumber)
		{
			itemSelectedOne = message;
			selectOne = itemNumber;
		}
		else if(selectTwo == -1 && selectOne != itemNumber)
		{
			itemSelectedTwo = message;
			selectTwo = itemNumber;
		}
		else
		{
			twoItemsSelected = false;
			clearSelectedItems();
			changedSelectedItem(itemNumber,message);
		}
		if (selectTwo != -1 && selectOne != -1) {
			twoItemsSelected = true;
		}

	}

	public void saveClues()
	{
		saveBooleanPref(bloodNoteFound, "bloodNoteFound");
		saveBooleanPref(policeNoteFound, "policeNoteFound");
		saveBooleanPref(villageEmptyFound, "villageEmptyFound");
		saveBooleanPref(knifeBloodFound, "knifeBloodFound");
		saveBooleanPref(priestRobesFound, "priestRobesFound");
		saveBooleanPref(photographPriestFound, "photographPriestFound");
		saveBooleanPref(journalDarknessFound, "journalDarknessFound");
		saveBooleanPref(journalPeopleFound, "journalPeopleFound");
		saveBooleanPref(journalFinalPieceFound, "journalFinalPieceFound");
		saveBooleanPref(letterFound, "letterFound");
		saveBooleanPref(villageDisappearedKnown, "villageDisappearedKnown");
		saveBooleanPref(murderedVillagersKnown, "murderedVillagersKnown");
		saveBooleanPref(knifeIsPriestKnown, "knifeIsPriestKnown");
		saveBooleanPref(priestIsMurdererKnown, "priestIsMurdererKnown");
		saveBooleanPref(priestIsShadyKnown, "priestIsShadyKnown");
		saveBooleanPref(townSacrificKnown, "townSacrificKnown");
		saveBooleanPref(oneMoreRequiredKnown, "oneMoreRequiredKnown");
		saveBooleanPref(priestTrappingPersonKnown, "priestTrappingPersonKnown");
		saveBooleanPref(FinalSacrificKnown, "FinalSacificKnown");
	}
	
	bool setBooleanVariable(int val)
	{
		if(val == 1)
		{
			return true;
		}
		return false;
	}

	public void saveBooleanPref(bool val, string name)
	{
		if (val) 
		{
			PlayerPrefs.SetInt(name, 1);
			return;
		}
		PlayerPrefs.SetInt(name, 0);
	}

	private void diplayClue(int select, int num)
	{
		int xStart = 0;
		int yStart = 0;
		if (num == 1) 
		{
			xStart = 10;
			yStart = 310;
		} 
		else 
		{
			xStart = 150 + DisplayWidth;
			yStart = 310;
		}

		if (select == LETTER) 
		{
			GUI.Box(new Rect(xStart,yStart,DisplayWidth,DisplayHeight),letterWords);
		}
		else if (select == BLOOD) 
		{
			GUI.Box(new Rect(xStart,yStart,DisplayWidth,DisplayHeight),bloodNote);
		}
		else if (select == POLICE) 
		{
			GUI.Box(new Rect(xStart,yStart,DisplayWidth,DisplayHeight),policeNote);
		}
		else if (select == DARK) 
		{
			GUI.Box(new Rect(xStart,yStart,DisplayWidth,DisplayHeight),journalDarkness);
		}
		else if (select == PEOPLE) 
		{
			GUI.Box(new Rect(xStart,yStart,DisplayWidth,DisplayHeight),journalPeople);
		}
		else if (select == FPIECE) 
		{
			GUI.Box(new Rect(xStart,yStart,DisplayWidth,DisplayHeight),journalFinalPiece);
		}
		else
		{
			if(num == 1)
			{
				GUI.Label(new Rect(xStart,yStart,DisplayWidth,DisplayHeight),itemSelectedOne);
			}
			else
			{
				GUI.Label(new Rect(xStart,yStart,DisplayWidth,DisplayHeight),itemSelectedTwo);
			}
		}

	}

	public void clueAchieved(int clueNum)
	{
		pickedUpClue = clueNum;
		if (newClueFound && !menuOpen && !canNotSeeClues) 
		{
			string word = null;
			string displayM = null;
			Texture displayT = null;
			if(clueNum == BLOOD)
			{
				word = "A Note Written In Blood";
				displayT = bloodNote;
				displayM = bloodNoteInfo;
				bloodNoteFound = true;
			}
			else if(clueNum == POLICE)
			{
				word = "A Police Memo";
				displayM = policeNoteInfo;
				displayT = policeNote;
				policeNoteFound = true;
			}
			else if(clueNum == EMPTY)
			{
				word = "The Village is Empty";
				displayM = villageEmptyInfo;
				displayT = villageEmpty;
				villageEmptyFound = true;
			}
			else if(clueNum == ROBES)
			{
				word = "Bloody Robes";
				displayM = priestRobesInfo;
				displayT = priestRobes;
				priestRobesFound = true;
			}
			else if(clueNum == BKNIFE)
			{
				word = "Bloody Knife";
				displayT = knifeBlood;
				displayM = bloodKnifeInfo;
				knifeBloodFound = true;
			}
			else if(clueNum == PHOTO)
			{
				word = "A PhotoGraph";
				displayM = photographPriestInfo;
				displayT = photographPriest;
				photographPriestFound = true;
			}
			else if(clueNum == DARK)
			{
				word = "A Page from the Priest's Journal";
				displayM = journalDarknessInfo;
				displayT = journalDarkness;
				journalDarknessFound = true;
			}
			else if(clueNum == PEOPLE)
			{
				word = "A Page from the Priest's Journal";
				displayM = journalPeopleInfo;
				displayT = journalPeople;
				journalPeopleFound = true;
			}
			else if(clueNum == FPIECE)
			{
				word = "A Page from the Priest's Journal";
				displayM = journalFinalPieceInfo;
				displayT = journalFinalPiece;
				journalFinalPieceFound = true;
			}
			else if(clueNum == PKNIFE)
			{
				word = "The Knife Belong's to the Priest";
				displayM = knifeIsPriestInfo;
				displayT = knifeIsPriest;
				knifeIsPriestKnown = true;
			}
			else if(clueNum == DISAPPEARED)
			{
				word = "The Villagers Have Disappeared";
				displayM = villageDisappearedInfo;
				displayT = villageDisappeared;
				villageDisappearedKnown = true;
			}
			else if(clueNum == MURDEREDV)
			{
				word = "Someone Murdered the Villagers";
				displayM = murderedVillagersInfo;
				displayT = murderedVillagers;
				murderedVillagersKnown = true;
			}
			else if(clueNum == PMURDERER)
			{
				word = "The High Priest Murdered the Villagers";
				displayM = priestIsMurdererInfo;
				displayT = priestIsMurderer;
				priestIsMurdererKnown = true;
			}
			else if(clueNum == SHADY)
			{
				word = "The High Priest is Involved In Something";
				displayM = priestIsShadyInfo;
				displayT = priestIsShady;
				priestIsShadyKnown = true;
			}
			else if(clueNum == SACRIFIC)
			{
				word = "The Village was Ritually Sacrificed";
				displayM = townSacrificInfo;
				displayT = townSacrific;
				townSacrificKnown = true;
			}
			else if(clueNum == MORE)
			{
				word = "The Ritual Requires One More Sacrifice";
				displayM = oneMoreRequiredInfo;
				displayT = oneMoreRequired;
				oneMoreRequiredKnown = true;
			}
			else if(clueNum == TRAP)
			{
				word = "The Priest is Attempting to Summon One More Sacrific";
				displayM = priestTrappingPersonInfo;
				displayT = priestTrappingPerson;
				priestTrappingPersonKnown = true;
			}
			else if(clueNum == FINAL)
			{
				FinalSacrificKnown = true;
				PlayerPrefs.SetInt("FinalSacrificKnown",1);
				gcc.gameComplete = true;
				MouseLook.noPrompt = true;
				return;
			}
			word = "New CLUE FOUND: " + word;
			GUI.Label (new Rect(200,200,700,25), word);
			GUI.Box (new Rect(200,235,700,300), displayT);
			GUI.Label (new Rect(200,545,700,200),displayM);

		}

	}

	public void restartClues()
	{
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

		bloodNoteFound = false;
		policeNoteFound = false;
		villageEmptyFound= false;
		knifeBloodFound = false;
		priestRobesFound= false;
		photographPriestFound= false;
		journalDarknessFound= false;
		journalPeopleFound= false;
		journalFinalPieceFound = false;
		letterFound= true;
		villageDisappearedKnown = false;
		murderedVillagersKnown = false;
		knifeIsPriestKnown= false;
		priestIsMurdererKnown= false;
		priestIsShadyKnown= false;
		townSacrificKnown= false;
		oneMoreRequiredKnown= false;
		priestTrappingPersonKnown= false;
		FinalSacrificKnown= false;
	}
	
}



