using UnityEngine;
using System.Collections;

public class MiddleBlockScript : MonoBehaviour {
	
	Vector3 vel;
	Vector3 speed;
	GameObject item;
	bool playerOnTop;
	public GameObject player;
	private ballscript otherScript;
	Vector3 up;
	Vector3 down;
	// Use this for initialization
	void Start () {
		vel = new Vector3( 0, -50, 0 );

		speed = new Vector3 (0, 1, 0);
		speed.Normalize();
		vel.Normalize ();
		player = GameObject.Find("Player");
		otherScript = player.GetComponent<ballscript> ();

		up = new Vector3 (0, 50, 0);
		Vector3 startPos = new Vector3 (0, 10, 0);
		transform.position = startPos;

	}


	void OnCollisionEnter(Collision collisionInfo)
	{

	}
	
	void OnCollisionStay(Collision collisionInfo)
	{

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (otherScript.goalMet && transform.position.y < 15) {

			transform.Translate((up*Time.fixedDeltaTime) /(60)); 
		} else if (!otherScript.goalMet && transform.position.y > -30) {
			vel -= speed;
			transform.Translate ((vel * Time.fixedDeltaTime) / (60 * 10));
		}

		
		
	}
}
