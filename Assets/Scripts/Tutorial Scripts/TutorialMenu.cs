using UnityEngine;
using System.Collections;

public class TutorialMenu : MonoBehaviour {

	public bool menuOpen = false;
	public bool canNotSeeClues = false;
	public bool newClueFound = false;
	public int pickedUpClue = -1;
	private bool attempt = false;
	public TutorialController tu;

	public Texture deathClue;
	public Texture monsterClue;
	public Texture sanityClue;

	public bool monsterFound;
	public bool sanityFound;
	public bool deathKnown;

	public const int MONSTER = 0;
	public const int SANITY = 1;
	public const int DEATH = 2;

	//These are the booleans that help combine two items
	public static bool twoItemsSelected = false;
	public static bool combined1 = false;
	public static bool combined2 = false;

	private int selectOne = -1;
	private int selectTwo = -1;
	private int combineID = -1;

	private string combinedMessage = null;
	private string attemptMessage = null;
	private int DisplayWidth = (Screen.width - 150) / 2;
	private int DisplayHeight = Screen.height - 300;


	// Use this for initialization
	void Start () {
		tu = GameObject.FindGameObjectWithTag("Tutorial").GetComponent<TutorialController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("GameStarted") == 0)
		{
			if(tu.clueTutorialDone)
			{
				if(Input.GetKeyDown("q"))
				{
					menuOpen = !menuOpen;
					clearSelectedItems();
				}

			}
			if(Input.anyKeyDown) 
			{
				newClueFound = false;
				if(deathKnown)
				{
					if(!tu.monsterSanTutorialDone)
					{
						tu.taskIsComplete = true;
					}
				}
			}
			if(monsterFound && sanityFound && !tu.clueTutorialDone)
			{
				if(tu.nextPrompt)
				{
					tu.taskIsComplete = true;
				}
			}
		}
	}

	void clearSelectedItems()
	{
		twoItemsSelected = false;
		attempt = false;
		attemptMessage = null;
		combinedMessage = null;
		selectOne = -1;
		selectTwo = -1;
	}

	bool canItemsCombine()
	{
		//POLICE + EMPTY = DISAPPEAR
		if ((selectOne == MONSTER || selectTwo == MONSTER) && (selectOne == SANITY || selectTwo == SANITY)) 
		{
			clearSelectedItems();
			clueAchieved(DEATH);
			return true;
		}
		return false;
	}

	public void clueAchieved(int clueNum)
	{
		pickedUpClue = clueNum;
		if (newClueFound && !menuOpen && !canNotSeeClues)
		{
			string word = null;
			Texture displayT = null;
			if(clueNum == MONSTER)
			{
				word = "The Village Might Be Haunted";
				displayT = monsterClue;
				monsterFound = true;
			}
			else if(clueNum == SANITY)
			{
				word = "Things Might Get Crazy";
				displayT = sanityClue;
				sanityFound = true;
			}
			else if(clueNum == DEATH)
			{
				word = "Mortality is Limiting";
				displayT = deathClue;
				deathKnown = true;
			}
			word = "New CLUE FOUND: " + word;
			GUI.Label (new Rect(200,200,700,25), word);
			GUI.Box (new Rect(200,235,700,300), displayT);
			
		}
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
		
		if (select == MONSTER) 
		{
			GUI.Box(new Rect(xStart,yStart,DisplayWidth,DisplayHeight),monsterClue);
		}
		else if (select == SANITY) 
		{
			GUI.Box(new Rect(xStart,yStart,DisplayWidth,DisplayHeight),sanityClue);
		}
		else if (select == DEATH) 
		{
			GUI.Box(new Rect(xStart,yStart,DisplayWidth,DisplayHeight),deathClue);
		}
	}

	void changedSelectedItem(int itemNumber)
	{
		attemptMessage = null;
		attempt = false;
		if(selectOne == itemNumber)
		{
			selectOne = -1;
			twoItemsSelected = false;
		}
		else if(selectTwo == itemNumber)
		{
			selectTwo = -1;
			twoItemsSelected = false;
		}
		else if(selectOne == -1 && selectTwo != itemNumber)
		{
			selectOne = itemNumber;
		}
		else if(selectTwo == -1 && selectOne != itemNumber)
		{
			selectTwo = itemNumber;
		}
		else
		{
			twoItemsSelected = false;
			clearSelectedItems();
			changedSelectedItem(itemNumber);
		}
		if (selectTwo != -1 && selectOne != -1) {
			twoItemsSelected = true;
		}
		if(!tu.menuTutorialDone && twoItemsSelected)
		{
			menuOpen = false;
			clearSelectedItems();
			tu.taskIsComplete = true;
		}
		
	}

	void OnGUI()
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
			}
			if(canNotSeeClues)
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
				
				if(monsterFound)
				{
					if(!deathKnown)
					{
						if(GUI.Button(new Rect(150, 70, 120, 100), monsterClue))
						{
							changedSelectedItem(MONSTER);
						}
					}
					else
					{
						if(GUI.Button(new Rect(150, 70, 120, 100), deathClue))
						{
							changedSelectedItem(DEATH);
						}
					}
				}
				else
				{
					GUI.Button(new Rect(150, 70, 120, 100), "Empty");
				}
				
				if(sanityFound)
				{
					if(!deathKnown)
					{
						if(GUI.Button(new Rect(280, 70, 120, 100), sanityClue))
						{
							changedSelectedItem(SANITY);
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
				
				GUI.Button(new Rect(410, 70, 120, 100), "Empty");
				GUI.Button(new Rect(540, 70, 120, 100), "Empty");
				GUI.Button(new Rect(670, 70, 120, 100), "Empty");
				GUI.Button(new Rect(150, 180, 120, 100), "Empty");
				GUI.Button(new Rect(280, 180, 120, 100), "Empty");
				GUI.Button(new Rect(410, 180, 120, 100), "Empty");
				GUI.Button(new Rect(540, 180, 120, 100), "Empty");
				GUI.Button(new Rect(670, 180, 120, 100), "Empty");

				//Display the Selected Clues
				
				if(selectOne != -1)
				{
					diplayClue(selectOne,1);
				}
				
				if(selectTwo != -1)
				{
					diplayClue(selectTwo,2);
				}


				if(tu.clueTutorialDone)
				{

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
}






