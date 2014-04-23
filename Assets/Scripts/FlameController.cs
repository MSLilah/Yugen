using UnityEngine;
using System.Collections;

public class FlameController : MonoBehaviour {
	public string clueKey;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt (clueKey) != 1) 
		{
			Destroy(this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
			
	
	}
}
