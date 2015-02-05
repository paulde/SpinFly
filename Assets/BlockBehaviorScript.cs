using UnityEngine;
using System.Collections;

public class BlockBehaviorScript : MonoBehaviour {

	// Use this for initialization
	int frameCounter;

	GameObject gb;
	void Start () {
		var trans = new Vector3 (5, 0, 1);
		frameCounter = 0;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (frameCounter == 60) 
		{
			//var x = Random.Range( -15, 15 );
			//var z = Random.Range( -15, 15 );
			float x = 0; 
			float z = 0;

			/*
			bool hasItem = false;
			if( Random.Range( 0, 5 ) == 0 )
			{
				hasItem = true;
			}*/

			float startDist = 30;
			if( Random.Range( 0, 1 ) == 0 )
			{
				x = startDist;
				z = Random.Range( -startDist, startDist );
			}
			else
			{
				x = Random.Range( -startDist, startDist );
				z = startDist;
			}
			
						var angle = Random.Range (0, Mathf.PI * 2 - .01f);
						var start = 30;
						//var startVel = .01f;
						var posOriginal = new Vector3 (Mathf.Cos (angle) * start, Random.Range( -14.0f, 15.0f ) , Mathf.Sin (angle) * start);
				// new Vector3( x, 0, z );
						//var vel = new Vector3 (-Mathf.Cos (angle) * start, 0, -Mathf.Sin (angle) * start);
						//pos.x *= 10;
						//pox.y *= 10;
						
						var rot = Quaternion.Euler( 0, Random.Range( 0.0f, 90.0f ), 0 );
						gb = (GameObject)Instantiate (Resources.Load ("BlockPrefab"), posOriginal, Quaternion.identity);
						var scale = new Vector3( Random.Range( -.5f, 3.0f ), 0, Random.Range( -.5f, 3.0f ) );

						//gb.transform.GetComponent<BlockScript>().SetItem(); 
						gb.transform.localScale += scale;
						
				//		gb.rigidbody.velocity = vel;
						//print ( gb.rigidbody.velocity.x + ", " + gb.rigidbody.velocity.y + ", " + gb.rigidbody.velocity.z );
						frameCounter = 0;
				
		} 
		else 
		{
			frameCounter++;

		}

		//gb.transform.Translate (-1 / 60.0f, 0, 0);
		//(gb.GetComponent<BlockScript> () as BlockScript).Blah ();
	}
}
