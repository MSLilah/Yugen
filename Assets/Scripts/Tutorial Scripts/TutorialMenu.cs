using UnityEngine;
using System.Collections;

public class TutorialMenu : MonoBehaviour {

	public bool menuOpen = false;
	public bool canNotSeeClues = false;
	public bool newClueFound = false;
	public int pickedUpClue = -1;
	private bool attempt = false;

	public Texture deathClue;
	public Texture monsterClue;
	public Texture sanityClue;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
