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
		//vel.y = 0;
		speed = new Vector3 (0, 1, 0);
		speed.Normalize();
		vel.Normalize ();
		player = GameObject.Find("Player");
		otherScript = player.GetComponent<ballscript> ();

		up = new Vector3 (0, 50, 0);
		Vector3 startPos = new Vector3 (0, 10, 0);
		transform.position = startPos;
		//speed = Random.Range( 2, 6 );
	}
	
	//public void Create( Vector3 vel, 

	void OnCollisionEnter(Collision collisionInfo)
	{
		
		/*if (collisionInfo.collider.tag == "Player") {
			collisionInfo.rigidbody.velocity += gameObject.rigidbody.velocity;

				}*/
		//print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
		//print("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
		//print("Their relative velocity is " + collisionInfo.relativeVelocity);
	}
	
	void OnCollisionStay(Collision collisionInfo)
	{
		
	/*	if (collisionInfo.collider.tag == "Player" && collisionInfo.contacts[0].normal.y < -.9 ) 
		{
			if( transform.position.y <= 15 )
			{
				playerOnTop = true;
				
				//	rigidbody.velocity = v;
				//	print ( "success: " + transform.position.x + ", " + transform.position.y + ", " + transform.position.z );
			}
			else
			{

			}*/
			
			
			

		//print(gameObject.name + " and " + collisionInfo.collider.name + " are still colliding");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		/*(float riseSpeed = 1;
		
			
			var v = new Vector3( 0, -(float)1.0 / 60 * riseSpeed, 0 );
			transform.Translate( v );
			//collisionInfo.rigidbody.AddForce( v );
			//collisionInfo.collider.transform.Translate( v );
			//collisionInfo.collider.rigidbody.MovePosition( collisionInfo.collider.rigidbody.position + v );
			
		
		
		
		
		float f = (transform.position.y) / 15;
		renderer.material.color = new Color (f, f, f);
		transform.Translate (vel / 60 * speed );
		
		if( item != null )
			item.transform.Translate (vel / 60 * speed);*/

		if (otherScript.goalMet && transform.position.y < 15) {
			//vel += speed;
			//Vector3  hi = new Vector3(0,50,0);
			transform.Translate((up*Time.fixedDeltaTime) /(60)); 
		} else if (!otherScript.goalMet && transform.position.y > -30) {
			vel -= speed;
			transform.Translate ((vel * Time.fixedDeltaTime) / (60 * 10));
		}
		//transofrm.Translate (vel);
		
		
	}
}
