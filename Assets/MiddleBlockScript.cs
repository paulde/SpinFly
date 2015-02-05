using UnityEngine;
using System.Collections;

public class MiddleBlockScript : MonoBehaviour {
	
	Vector3 vel;
	float speed;
	GameObject item;
	bool playerOnTop;
	// Use this for initialization
	void Start () {
		vel = new Vector3( 0, -1, 0 );
		vel.y = 0;
		vel.Normalize ();
		speed = Random.Range( 2, 6 );
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
		
		
	}
}
