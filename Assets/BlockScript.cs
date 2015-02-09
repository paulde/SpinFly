using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {

	Vector3 vel;
	float speed;
	// Use this for initialization
	void Start () {
		vel = -transform.position;
		vel.Normalize ();
		speed = Random.Range( 1, 5 );

		//Determine if block is a bonus block
		int randNum = Random.Range (1, 5);
		if (randNum == 1) 
		{
			transform.gameObject.tag= "Bonus";
		}
	}

	//public void Create( Vector3 vel, 

	void OnCollisionEnter(Collision collisionInfo)
	{
		if(collisionInfo.gameObject.name == "Player" && transform.gameObject.tag=="Bonus")
		{
			for(int i = 0; i < transform.childCount;i++)
			{
				transform.GetChild(i).gameObject.renderer.enabled = false;
			}
			//Renderer[] childRenderer = GetComponentInChildren<Renderer>();
			//childRenderer.enabled = false;
			//transform.GetChild
			/*foreach (Renderer renderer in childrenRenderer) 
			{

			}*/
		}

	/*	if (gameObject.tag == "Player") {
			if( transform.position.y <= 10 )
			{
				transform.Translate( 0, 1, 0 );
			}

				}*/
		//print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
		//print("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
		//print("Their relative velocity is " + collisionInfo.relativeVelocity);
	}
	
	void OnCollisionStay(Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "Player")
		{
			transform.gameObject.tag = "Block";
		}
		if (collisionInfo.collider.tag == "Player" && collisionInfo.contacts[0].normal.y < -.9 ) {
			if( transform.position.y <= 4 )
			{
				var v = new Vector3( 0, (float)1.0 / 60, 0 );
				transform.Translate( v );
			//	rigidbody.velocity = v;
			//	print ( "success: " + transform.position.x + ", " + transform.position.y + ", " + transform.position.z );
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
		renderer.material.OutlineColor = new Color (f, f, f);
		//var bone = this.transform.Find("Bonus");
		//Vector3 d = new Vector3 (0,0,0);
		//transform.particleSystem.enableEmission = true;
		//transform.particleSystem.Emit ();
		transform.Translate (vel / 60 * speed );


	}
}
