using UnityEngine;
using System.Collections;

public class PlayerInitialPlacementController : MonoBehaviour {

	public static Vector3 lastKnownPlayerPosition;
	public static Quaternion lastKnownPlayerRotation;
	public static bool movePlayer = false;
	// Use this for initialization
	void Start () {
		if (movePlayer) {
			gameObject.transform.position = lastKnownPlayerPosition;
			gameObject.transform.rotation = lastKnownPlayerRotation;
			transform.eulerAngles = new Vector3(0,180,0);
		}
	}
}
