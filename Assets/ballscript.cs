using UnityEngine;
using System.Collections;

public class ballscript : MonoBehaviour {
	public Vector3 test;
	public GUIText scoreText;
	public int score;
	bool hasJump;
	// Use this for initialization
	void Start () {
		hasJump = true;
		score = 0;
		displayScore ();
		//print ("ball start: " + rigidbody.transform.position.x + ", " + rigidbody.transform.position.y + ", " 
		 //      + rigidbody.transform.position.z);
		//Physics.gravity = new Vector3 (0, -.0f, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//print ("ball vel: " + rigidbody.transform.position.x + ", " + rigidbody.transform.position.y + ", " 
						//+ rigidbody.transform.position.z);
		float forceFactor = 10 * rigidbody.mass;
		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey( KeyCode.W ) ) {
			rigidbody.AddForce( 0, 0, forceFactor );
		}

		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey( KeyCode.S) ) {
			rigidbody.AddForce( 0, 0, -forceFactor );
		}

		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey( KeyCode.A) ) {
			rigidbody.AddForce( -forceFactor, 0, 0 );
		}

		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey( KeyCode.D) ) {
			rigidbody.AddForce( forceFactor, 0, 0 );
		}



		if (Input.GetKey(KeyCode.Space) && hasJump) {
			hasJump = false;
			rigidbody.velocity = new Vector3( rigidbody.velocity.x, 8, rigidbody.velocity.z );
			//rigidbody.AddExplosionForce(, );
				}
		displayScore ();
	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "Block") {//&& collisionInfo.contacts [0].normal.y > .99) {
						hasJump = true;
			
						//print ("has jump");
				} else if (collisionInfo.collider.tag == "Ground") {
						Application.LoadLevel (Application.loadedLevel);
						print ("Resetting");
				} else if (collisionInfo.collider.tag == "Item") {
					//print ( "item!!!" );
					//Destroy( collisionInfo.collider );
				}
		if (collisionInfo.collider.tag == "Bonus")
		{
			score++;
		}
		if (collisionInfo.collider.tag == "Ground")
		{
			score = 0;
		}

	}

	void OnCollisionStay(Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "Block" ){//&& collisionInfo.contacts [0].normal.y > .99) {
			hasJump = true;
			
			//print ("has jump");
		} 
	}

	void displayScore()
	{
		scoreText.text = "Score: " + score.ToString ();
	}
	
}
