using UnityEngine;
using System.Collections;



public class ItemMenu : MonoBehaviour {

	bool menuOpen = false;
	bool attempt = false;
	public bool letterFound = false;
	public bool axeFound = false;
	public bool parchmentFound = false;
	public bool sealFound = false;
	public bool twoItemsSelected = false;
	public bool combined1 = false;
	public bool combined2 = false;

	public Texture letterTexture;
	public Texture axeTexture;
	public Texture combinedTexture;
	public Texture parchmentTexture;
	public Texture sealTexture;
	public Texture combinedTexture2;

	public const int LETTERS = 0;
	public const int AXE = 1;
	public const int SEAL = 2;
	public const int PAPER = 3;
	public const int TEMP = 4;

	int selectOne = -1;
	int selectTwo = -1;
	int combineID = -1;

	string axeInfo = "The old rotten axe, has clearly been used for devious means.\n";
	string letterInfo = "Listen, I figured it out. \n \tAll the answers are there. \n The Village holds the solution!\n";
	string combindedInfo1 = "Clearly the Family Sona was the lord of this manor\n";
	string sealInfo = "This is a seal of the Sona Family\n";
	string parchmentInfo = "A Letter of ownership of the village\n";
	string itemSelectedOne = null;
	string itemSelectedTwo = null;
	string combinedMessage = null;
	string attemptMessage = null;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("q"))
		{
			menuOpen = !menuOpen;
			clearSelectedItems();
		}
	
	}
	

	void OnGUI()
	{
		if (menuOpen) 
		{
						// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
						if (GUI.Button (new Rect (10, 40, 120, 50), "Back to Game")) {
								//Application.LoadLevel("moveChanges");
						}

						// Make the second button.
						if (GUI.Button (new Rect (10, 100, 120, 50), "Clues")) {
								//Application.LoadLevel("ControlInfo");
						}

						if (GUI.Button (new Rect (10, 160, 120, 50), "Collectibles")) {
								//Application.LoadLevel("GameCredits");
						}
		
						if (GUI.Button (new Rect (10, 220, 120, 50), "Quit Game")) {
								Application.Quit();
						}

			if(letterFound == true)
			{
				if(GUI.Button(new Rect(150, 40, 120, 100), letterTexture))
				{
					changedSelectedItem(LETTERS, letterInfo);
				}
			}
			else
			{
				GUI.Button(new Rect(150, 40, 120, 100), "Empty");
			}

			if(axeFound)
			{
				if(GUI.Button(new Rect(280, 40, 120, 100), axeTexture))
				{
					changedSelectedItem(AXE, axeInfo);
				}
			}
			else
			{
				GUI.Button(new Rect(280, 40, 120, 100), "Empty");
			}

			if(sealFound || combined1)
			{
				if(combined1 == false)
				{
					if(GUI.Button(new Rect(410, 40, 120, 100), sealTexture))
					{
						changedSelectedItem(SEAL, sealInfo);
					}
				}
				else
				{
					if(GUI.Button(new Rect(410, 40, 120, 100), combinedTexture))
					{
						changedSelectedItem(TEMP, combinedMessage);
					}
				}
			}
			else
			{
				GUI.Button(new Rect(410, 40, 120, 100), "Empty");
			}

			if(parchmentFound || combined1)
			{
				if(combined1 == false)
				{
					if(GUI.Button(new Rect(540, 40, 120, 100), parchmentTexture))
					{
						changedSelectedItem(PAPER, parchmentInfo);
					}
				}
				else
				{
					GUI.Button(new Rect(540, 40, 120, 100), "Item Used");
				}
			}
			else
			{
				GUI.Button(new Rect(540, 40, 120, 100), "Empty");
			}

			if(itemSelectedOne != null)
			{
				GUI.Label(new Rect(20, Screen.height/2 - 10, 200, 200),itemSelectedOne);
			}
			if(itemSelectedTwo != null)
			{
				GUI.Label(new Rect((Screen.width/2)-10, Screen.height/2 - 10, 200, 200),itemSelectedTwo);
			}

			if(twoItemsSelected)
			{
				if(GUI.Button(new Rect((Screen.width/2)-210, Screen.height/2 - 10, 120, 100), "Combine Items?"))
				{
					attempt = true;
					if(canItemsCombine())
					{
						clearSelectedItems();
						attemptMessage = "These things make more sense together!";
					}
					else
					{
						attemptMessage = "These items mean nothing together!";
					}
				}

			}

			if(attempt)
			{
				GUI.Label(new Rect((Screen.width/2), Screen.height/2 - 100, 200, 200),attemptMessage);
			}
				
		}
		
		
	}
	
	bool canItemsCombine()
	{
		if ((selectOne == SEAL || selectTwo == SEAL) && (selectOne == PAPER || selectTwo == PAPER)) 
		{
			clearSelectedItems();
			itemSelectedOne = combindedInfo1;
			selectOne = TEMP;
			combined1 = true;
			return true;
		}
		return false;
	}

	void clearSelectedItems()
	{
		itemSelectedOne = null;
		itemSelectedTwo = null;
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
		if (selectTwo != -1 && selectOne != -1) {
			twoItemsSelected = true;
		}

	}
	
}
