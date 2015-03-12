using UnityEngine;
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
	// Use this for initialization
	void Start () {
		hasJump = true;
		score = 0;
		displayScore ();
		//print ("ball start: " + rigidbody.transform.position.x + ", " + rigidbody.transform.position.y + ", " 
		 //      + rigidbody.transform.position.z);
		time = 60;
		Physics.gravity = new Vector3 (0, -20, 0);
		goalMet = false;
		goal = 3;
		//GameObject.Find ("Fader").GetComponent<Fade> ().FadetoBlack ();
		//yield return new WaitForSeconds (fadeTime);
		//test ();
		//testfunction ();
		GameObject.Find ("Fader").GetComponent<Fade> ().FadeIn ();

		player = GameObject.Find("Player");
		otherScript = player.GetComponent<ballscript> ();
		//otherScript = player.GetComponent<ballscript> ();

		//yield return new WaitForSeconds (fadeTime);
		controlType = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//print ("ball vel: " + rigidbody.transform.position.x + ", " + rigidbody.transform.position.y + ", " 
						//+ rigidbody.transform.position.z);

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
			//rigidbody.AddExplosionForce(, );
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
			//rigidbody.AddExplosionForce(, );
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
			//rigidbody.AddExplosionForce(, );
				}


//>>>>>>> Stashed changes
			if(rigidbody.velocity.magnitude > max_speed)
         	{
                rigidbody.velocity = rigidbody.velocity.normalized * max_speed;
         	}
		}

		if (Input.GetKey (KeyCode.U)) {
			GameObject powerUP = (GameObject)Instantiate (Resources.Load ("PowerUp"),new Vector3(-4,12,10), Quaternion.identity);
			powerUP.transform.Rotate( new Vector3(331.5f, 164.06f, 316.75f));
		}
		
		

		displayScore ();

		float f = (transform.position.y) / 25;
		//renderer.material.color = new Color (f, f, f);
		
		//renderer.material.shader = Shader.Find ("SciFi_Props-Pack03-diffuse");
		//renderer.material.SetColor ("_OutlineColor", new Color (f, f, f));
		if (goalMet != true) {
						time -= Time.fixedDeltaTime;
				}
		if (time <= 0) {
			Application.LoadLevel (Application.loadedLevel);
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
			
						//print ("has jump");
				} else if (collisionInfo.collider.tag == "Ground") {
						float fadeTime = GameObject.Find ("Player").GetComponent<Fade>().BeginFade(1);
						yield return new WaitForSeconds(fadeTime);
						Application.LoadLevel (Application.loadedLevel);
						print ("Resetting");
				} else if (collisionInfo.collider.tag == "Item") {
					//print ( "item!!!" );
					//Destroy( collisionInfo.collider );
				}

				//Allows players recovery
				if (collisionInfo.collider.name == "PowerUp") {
					rigidbody.velocity = new Vector3( rigidbody.velocity.x, 25, rigidbody.velocity.z );
				}

		//if (collisionInfo.collider.tag == "Bonus")
		//{
			//score++;
		//}
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
		scoreText.text = "Time: " + time.ToString("0") + "\nGoal: " + score.ToString () + "/" + goal;
	}
	/*IEnumerator testfunction() 
	{
		float fadeTime = GameObject.Find ("Fader").GetComponent<Fade> ().BeginFade (-1);
		yield return new WaitForSeconds(fadeTime);
	}*/


	
}
