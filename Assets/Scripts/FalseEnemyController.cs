using UnityEngine;
using System.Collections;

public class FalseEnemyController : MonoBehaviour {
	private NavMeshAgent nav;
	private Transform player;
	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		nav.destination = player.position;
	}

	void OnCollisionStay(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			Object.Destroy (gameObject);
		}
	}
}
