using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {

	public Vector3 vel;
	public float speed;
	public float original_speed;

	public GameObject player;
	private ballscript otherScript;

	// Use this for initialization
	void Start () {

		speed = Random.Range( 2, 5 );
		original_speed = speed;

		player = GameObject.Find("Player");
		otherScript = player.GetComponent<ballscript> ();
		
	}

	public void SetVelocity( Vector3 v )
	{
		vel = v;

		vel.Normalize ();
	}

	//public void Create( Vector3 vel, 


	
	void OnCollisionStay(Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "Player" && collisionInfo.contacts[0].normal.y < -.9 ) {
			if( transform.position.y <= 4 )
			{
				var v = new Vector3( 0, (float)1.0 / 60, 0 );
				transform.Translate( v );
			}


			
		}

	}


	
	// Update is called once per frame
	void FixedUpdate () {
		float f = (transform.position.y) / 4;
		if (otherScript.goalMet == true) 
		{
			speed = 0;
		}else if (otherScript.slow_isOn == true) {
			speed = 1;
		} else {
			speed = original_speed;
		}

		transform.Translate (vel / 60 * speed );


	}
}
