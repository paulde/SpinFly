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
	// Use this for initialization
	void Start () {
		hasJump = true;
		score = 0;
		displayScore ();
		//print ("ball start: " + rigidbody.transform.position.x + ", " + rigidbody.transform.position.y + ", " 
		 //      + rigidbody.transform.position.z);
		time = 60;
		Physics.gravity = new Vector3 (0, -15, 0);
		goalMet = false;
		goal = 1;
		//GameObject.Find ("Fader").GetComponent<Fade> ().FadetoBlack ();
		//yield return new WaitForSeconds (fadeTime);
		//test ();
		//testfunction ();
		GameObject.Find ("Fader").GetComponent<Fade> ().FadeIn ();

		player = GameObject.Find("Player");
		otherScript = player.GetComponent<ballscript> ();
		//otherScript = player.GetComponent<ballscript> ();

		//yield return new WaitForSeconds (fadeTime);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//print ("ball vel: " + rigidbody.transform.position.x + ", " + rigidbody.transform.position.y + ", " 
						//+ rigidbody.transform.position.z);
		float forceFactor = 15 * rigidbody.mass;
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
			rigidbody.velocity = new Vector3( rigidbody.velocity.x, 9, rigidbody.velocity.z );
			//rigidbody.AddExplosionForce(, );
				}
		displayScore ();

		float f = (transform.position.y) / 25;
		//renderer.material.color = new Color (f, f, f);
		
		//renderer.material.shader = Shader.Find ("SciFi_Props-Pack03-diffuse");
		renderer.material.SetColor ("_OutlineColor", new Color (f, f, f));
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
