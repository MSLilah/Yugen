using UnityEngine;
using System.Collections;

public class PlayerInitialPlacementController : MonoBehaviour {

	public static Vector3 lastKnownPlayerPosition;
	public static Quaternion lastKnownPlayerRotation;
	public static bool movePlayer = false;
	// Use this for initialization
	void Start () {
		Debug.Log ("Initializing");
		if (movePlayer) {
			Debug.Log ("Placing player");
			gameObject.transform.position = lastKnownPlayerPosition;
			gameObject.transform.rotation = lastKnownPlayerRotation;
			transform.eulerAngles = new Vector3(0,180,0);
		}
	}
}
