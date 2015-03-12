using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {

	Vector3 vel;
	float speed;
	public bool isBonus;
	public GameObject player;
	private ballscript otherScript;
	// Use this for initialization
	void Start () {
		//vel = new Vector3( 0, 0, 0 );
		//vel = -transform.position;

		speed = Random.Range( 2, 5 );



		//Determine if block is a bonus block
		int randNum = Random.Range (1, 3);
		if (randNum == 1) 
		{
			Debug.Log("TRUE");
			isBonus = true;
		}

		player = GameObject.Find("Player");
		otherScript = player.GetComponent<ballscript> ();

	}

	public void SetVelocity( Vector3 v )
	{
		vel = v;
		//vel = new Vector3( Random.Range( -1.0f, 1.0f ), 0, Random.Range( -1.0f, 1.0f ) );
		vel.Normalize ();
	}

	//public void Create( Vector3 vel, 

	void OnCollisionEnter(Collision collisionInfo)
	{
		if(collisionInfo.gameObject.name == "Player")
		{
			for(int i = 0; i < transform.childCount;i++)
			{
				transform.GetChild(i).gameObject.renderer.enabled = false;
			}

		}
		if(isBonus == true && collisionInfo.gameObject.name == "Player"){
			isBonus = false;
			if(otherScript.goalMet != true){
				otherScript.score += 1;
			}

			
			}
	
	}
	
	void OnCollisionStay(Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "Player")
		{
			//transform.gameObject.tag = "Block";
			isBonus = false;
		}
		if (collisionInfo.collider.tag == "Player" && collisionInfo.contacts[0].normal.y < -.9 ) {
			if( transform.position.y <= 4 )
			{
				var v = new Vector3( 0, (float)1.0 / 60, 0 );
				transform.Translate( v );
			}
			else
			{
			//	print ( "fail: " );
			}


			
		}
		//print(gameObject.name + " and " + collisionInfo.collider.name + " are still colliding");
	}


	
	// Update is called once per frame
	void FixedUpdate () {
		float f = (transform.position.y) / 4;

		transform.Translate (vel / 60 * speed );

		//Debug.Log ("HI");


	}
}
