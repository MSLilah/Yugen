using UnityEngine;
using System.Collections;

public class PlayerSight : MonoBehaviour {
	public float fieldOfViewAngle = 180f;
	public bool enemyInSight = false;
	public SanityBarController sbc;
	
	private SphereCollider col;
	
	void Start() 
	{
		col = GetComponent<SphereCollider> ();
		sbc = GameObject.FindGameObjectWithTag("GameController").GetComponent<SanityBarController> ();
	}
	
	void OnTriggerStay (Collider other)
	{
		// If the player has entered the trigger sphere...
		if(other.gameObject.tag == "Enemy")
		{
			Debug.Log("Enemy close");
			// By default the enemy is not in sight.
			enemyInSight = false;
			
			// Create a vector from the enemy to the player and store the angle between it and forward.
			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);
			
			// If the angle between forward and where the player is, is less than half the angle of view...
			if(angle < fieldOfViewAngle * 0.5f)
			{
				RaycastHit hit;
				
				// ... and if a raycast towards the player hits something...
				if(Physics.Raycast(transform.position/* + transform.up*/, direction.normalized, out hit, col.radius))
				{
					// ... and if the raycast hits the enemy...
					if(hit.collider.gameObject.tag == "Enemy")
					{
						// ... the enemy is in sight.
						enemyInSight = true;
					}
				}
			}
		}
	}
	
	void Update() {
		if (enemyInSight) {
			sbc.currSanity -= 0.1f;
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		// If the player leaves the trigger zone...
		if(other.gameObject.tag == "Enemy")
			// ... the player is not in sight.
			enemyInSight = false;
	}
}
