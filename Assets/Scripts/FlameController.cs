using UnityEngine;
using System.Collections;

public class FlameController : MonoBehaviour {
	public string clueKey;
	public ItemMenu im;
	// Use this for initialization
	void Start () 
	{
		im = GameObject.FindGameObjectWithTag("ItemMenu").GetComponent<ItemMenu> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!cluefound()) 
		{
			this.gameObject.SetActive(false);
		}
		else
		{
			this.gameObject.SetActive(true);
		}
	}

	bool cluefound()
	{
		if(clueKey.Equals("bloodNoteFound"))
		{
			return im.bloodNoteFound;
		}
		else if(clueKey.Equals("policeNoteFound"))
		{
			return im.policeNoteFound;
		}
		else if(clueKey.Equals("villageEmptyFound"))
		{
			return im.villageEmptyFound;
		}
		else if(clueKey.Equals("knifeBloodFound"))
		{
			return im.knifeBloodFound;
		}
		else if(clueKey.Equals("priestRobesFound"))
		{
			return im.priestRobesFound;
		}
		else if(clueKey.Equals("photographPriestFound"))
		{
			return im.photographPriestFound;
		}
		else if(clueKey.Equals("journalDarknessFound"))
		{
			return im.journalDarknessFound;
		}
		else if(clueKey.Equals("journalPeopleFound"))
		{
			return im.journalPeopleFound;
		}
		else if(clueKey.Equals("journalFinalPieceFound"))
		{
			return im.journalFinalPieceFound;
		}
		else if(clueKey.Equals("villageDisappearedKnown"))
		{
			return im.villageDisappearedKnown;
		}
		else if(clueKey.Equals("murderedVillagersKnown"))
		{
			return im.murderedVillagersKnown;
		}
		else if(clueKey.Equals("knifeIsPriestKnow"))
		{
			return im.knifeIsPriestKnown;
		}
		else if(clueKey.Equals("priestIsShadyKnown"))
		{
			return im.priestIsShadyKnown;
		}
		else if(clueKey.Equals("townSacrificKnown"))
		{
			return im.townSacrificKnown;
		}
		else if(clueKey.Equals("oneMoreRequiredKnown"))
		{
			return im.oneMoreRequiredKnown;
		}
		else if(clueKey.Equals("priestTrappingPersonKnown"))
		{
			return im.priestTrappingPersonKnown;
		}
		else if(clueKey.Equals("FinalSacrificKnown"))
		{
			return im.FinalSacrificKnown;
		}
		else if(clueKey.Equals("letterFound"))
		{
			return im.letterFound;
		}
		return false;
	}
}
