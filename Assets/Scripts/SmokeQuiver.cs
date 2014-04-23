using UnityEngine;
using System.Collections;


public class SmokeQuiver : MonoBehaviour {
	private ParticleEmitter smoke;
	public float randomScale;
	public float startSmoke;
	public float toAdd;
	
	// Use this for initialization
	void Start () {
		float y = GameObject.FindGameObjectWithTag ("Smoke").GetComponent<ParticleEmitter> ().localVelocity.y;
		float z = GameObject.FindGameObjectWithTag ("Smoke").GetComponent<ParticleEmitter> ().localVelocity.z;
		//GameObject.FindGameObjectWithTag ("Smoke").GetComponent<ParticleEmitter> ().localVelocity = new Vector3 (.0001f, 0.0f,0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
		
		float x = GameObject.FindGameObjectWithTag ("Smoke").GetComponent<ParticleEmitter> ().worldVelocity.x;
		Debug.Log ("current velocity");
		Debug.Log (x);
		if (x < randomScale-.4) 
		{
			toAdd = -toAdd;
		}
		if(GameObject.FindGameObjectWithTag ("Smoke").GetComponent<ParticleEmitter>().worldVelocity.x > randomScale) 
		{
			toAdd = -toAdd;
		}
		startSmoke += toAdd;
		Debug.Log("startSmoke");
		Debug.Log (startSmoke);
		Vector3 toSet = new Vector3 (startSmoke, .1f, .1f);
		GameObject.FindGameObjectWithTag ("Smoke").GetComponent<ParticleEmitter> ().worldVelocity = toSet;

		
		
	}
}
