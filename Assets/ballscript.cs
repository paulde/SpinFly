﻿using UnityEngine;
using System.Collections;

public class ballscript : MonoBehaviour {
	public Vector3 test;
	public GUIText scoreText;
	public int score;
	bool hasJump;
	public float time;
	public bool goalMet;
	public int goal;
	public GameObject player;
	private ballscript otherScript;
	private int controlType;
	public bool slow_isOn;
	public bool net_isOn;
	public float powerUp_time;
	public float POWERUP_DURATION = 10;

	public GameObject block;
	private BlockTop_script top;

	// Use this for initialization
	void Start () {
		hasJump = true;
		score = 0;
		displayScore ();

		time = 60;
		Physics.gravity = new Vector3 (0, -20, 0);
		goalMet = false;
		goal = 3;

		GameObject.Find ("Fader").GetComponent<Fade> ().FadeIn ();

		player = GameObject.Find("Player");
		otherScript = player.GetComponent<ballscript> ();

		controlType = 3;

		slow_isOn = false;
		net_isOn = false;
		powerUp_time = POWERUP_DURATION;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

		if (Input.GetKey (KeyCode.Alpha1)) {
			controlType = 1;
		} else if (Input.GetKey (KeyCode.Alpha2)) {
			controlType = 2;
		} else if (Input.GetKey (KeyCode.Alpha3)) {
			controlType = 3;
		}


		if (controlType == 1) { // Original controls
			float forceFactor = 15 * rigidbody.mass;
			if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
				rigidbody.AddForce (0, 0, forceFactor);
			}
			if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {
				rigidbody.AddForce (0, 0, -forceFactor);
			}
			if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
				rigidbody.AddForce (-forceFactor, 0, 0);
			}
			if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
				rigidbody.AddForce (forceFactor, 0, 0);
			}

			if (Input.GetKey(KeyCode.Space) && hasJump) {
			hasJump = false;
			rigidbody.velocity = new Vector3( rigidbody.velocity.x, 7, rigidbody.velocity.z );
		
				}
		} else if(controlType == 2) { // Version 2 Control
			if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
				transform.Translate (Vector3.forward * 20f * Time.fixedDeltaTime, transform.parent);
			}
			if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {
				transform.Translate (Vector3.back * 20f * Time.fixedDeltaTime, transform.parent);
			}
			if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
				transform.Translate (Vector3.left * 20f * Time.fixedDeltaTime, transform.parent);
			}
			if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
				transform.Translate (Vector3.right * 20f * Time.fixedDeltaTime, transform.parent);
				//transform.Rotate (0, 0, 5);
			}

			if (Input.GetKey(KeyCode.Space) && hasJump) {
			hasJump = false;
			rigidbody.velocity = new Vector3( rigidbody.velocity.x, 7, rigidbody.velocity.z );
			
				}
		}
		else if(controlType == 3) { // Version 2 Control
			float forceFactor = 25 * rigidbody.mass;
			if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
				rigidbody.AddForce (0, 0, forceFactor);
			}
			if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {
				rigidbody.AddForce (0, 0, -forceFactor);
			}
			if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
				rigidbody.AddForce (-forceFactor, 0, 0);
			}
			if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
				rigidbody.AddForce (forceFactor, 0, 0);
			}

//<<<<<<< Updated upstream
			float max_speed = 12;
//=======
			if (Input.GetKey(KeyCode.Space) && hasJump) {
			hasJump = false;
			rigidbody.velocity = new Vector3( rigidbody.velocity.x, 20, rigidbody.velocity.z );
			
				}


//>>>>>>> Stashed changes
			if(rigidbody.velocity.magnitude > max_speed)
         	{
                rigidbody.velocity = rigidbody.velocity.normalized * max_speed;
         	}
		}
		

		displayScore ();

		float f = (transform.position.y) / 25;

		if (goalMet != true) {
						time -= Time.fixedDeltaTime;
		}
		if (time <= 0) {
			Application.LoadLevel (Application.loadedLevel);
		}
		if (slow_isOn == true) {
			powerUp_time -= Time.fixedDeltaTime;

			if(powerUp_time <= 0){
				slow_isOn = false;
			}
		} 
		if (score >= goal || Input.GetKey(KeyCode.H)) {
			goalMet = true;
		}

		if (transform.position.y >= 44) {
			GameObject.Find ("Fader").GetComponent<Fade> ().FadeOut ();
			Application.LoadLevel (Application.loadedLevel);
		}

	}

	IEnumerator OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "Block") {//&& collisionInfo.contacts [0].normal.y > .99) {
						hasJump = true;
			
						
				} else if (collisionInfo.collider.tag == "Ground") {
						float fadeTime = GameObject.Find ("Player").GetComponent<Fade>().BeginFade(1);
						yield return new WaitForSeconds(fadeTime);
						Application.LoadLevel (Application.loadedLevel);
						print ("Resetting");
				}

				//Allows players recovery
				if (collisionInfo.collider.tag == "PowerUp") {
					rigidbody.velocity = new Vector3( rigidbody.velocity.x, 50, rigidbody.velocity.z );
					slow_isOn = true;
					powerUp_time = POWERUP_DURATION;
				}


			if (collisionInfo.collider.tag == "Ground")
			{
				score = 0;
			}

	}

	void OnCollisionStay(Collision collisionInfo)
	{
		Debug.Log ("HERE");
		Debug.Log (collisionInfo.collider.tag);
		if (collisionInfo.collider.tag == "Block" ||
		    collisionInfo.collider.tag == "BlockTop"){
			hasJump = true;
			
		}
		if (collisionInfo.collider.tag == "BlockTop" && 
		    !(Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W) ||
		  		Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S) ||
		  		Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.A) ||
		  		Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.D) ||
		  		Input.GetKey (KeyCode.Space))) {

			rigidbody.velocity = new Vector3(0,rigidbody.velocity.y,0);
			rigidbody.angularVelocity = Vector3.zero;
			Vector3 vel =  collisionInfo.gameObject.GetComponent<BlockTop_script> ().vel;
			vel.y = rigidbody.velocity.y;
			float speed = collisionInfo.gameObject.GetComponent<BlockTop_script> ().speed;
			transform.Translate (vel / 60 * speed );
		}
		if (collisionInfo.collider.tag == "Block" ||
		    collisionInfo.collider.tag == "BlockTop"){
			hasJump = true;
			
		}

	}

	void displayScore()
	{
		scoreText.text = "Time: " + time.ToString("0") + "\nGoal: " + score.ToString () + "/" + goal + "\n" + slow_isOn;
	}

}
