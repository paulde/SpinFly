using UnityEngine;
using System.Collections;

public class BlockBehaviorScript : MonoBehaviour {
	
	// Use this for initialization
	int frameCounter;
	int numStartingPlatforms;
	float borderDistance;
	GameObject gb;
	int minPlatforms;
	void Start () {
		var trans = new Vector3 (5, 0, 1);
		frameCounter = 0;
		minPlatforms = 30;
		borderDistance = 30;
		
		float x = 0;
		float z = 0;
		
		for( int i = 0; i < minPlatforms; ++i )
		{
			x = Random.Range( -borderDistance + 5, borderDistance - 5 );
			z = Random.Range( -borderDistance + 5, borderDistance - 5 );
			
			
			
			var posOriginal = new Vector3 ( x, Random.Range( 3.0f, 9.0f ) , z);
			
			
				gb = (GameObject)Instantiate (Resources.Load ("BlockPrefab"), posOriginal, Quaternion.identity);
				((BlockScript)gb.GetComponent( "BlockScript" )).SetVelocity( new Vector3( Random.Range( -1.0f, 1.0f ), 0, Random.Range( -1.0f, 1.0f ) ) );
			var scale = new Vector3( Random.Range( -.5f, 3.0f ), 0, Random.Range( -.5f, 3.0f ) );
			
			//gb.transform.GetComponent<BlockScript>().SetItem(); 
				gb.transform.localScale += scale;
			
			//		gb.rigidbody.velocity = vel;
			//print ( gb.rigidbody.velocity.x + ", " + gb.rigidbody.velocity.y + ", " + gb.rigidbody.velocity.z );
			frameCounter = 0;
		}
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GameObject [] allBlocks = GameObject.FindGameObjectsWithTag( "Block" );
		int deleteCount = 0;
		foreach( GameObject block in allBlocks )
		{
			if( block.transform.position.x < -borderDistance ||
			   block.transform.position.x > borderDistance ||
			   block.transform.position.z < -borderDistance ||
			   block.transform.position.z > borderDistance )
			{
				Object.Destroy( block );
				++deleteCount;
			}
			
		}
		
		for( int i = 0; i < deleteCount; ++i )
		{
			deleteCount = 0;
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
			var posOriginal = new Vector3 (Mathf.Cos (angle) * start, Random.Range( 3.0f, 9.0f ) , Mathf.Sin (angle) * start);
			// new Vector3( x, 0, z );
			//var vel = new Vector3 (-Mathf.Cos (angle) * start, 0, -Mathf.Sin (angle) * start);
			//pos.x *= 10;
			//pox.y *= 10;
			
			var rot = Quaternion.Euler( 0, Random.Range( 0.0f, 90.0f ), 0 );
			gb = (GameObject)Instantiate (Resources.Load ("BlockPrefab"), posOriginal, Quaternion.identity);
			Vector3 blockVel = new Vector3( Random.Range( -1.0f, 1.0f ), 0, Random.Range( -1.0f, 1.0f ) );
			blockVel.Normalize();
			if( posOriginal.x > 0 && blockVel.x > 0 ) blockVel.x = -blockVel.x;
			if( posOriginal.x < 0 && blockVel.x < 0 ) blockVel.x = -blockVel.x;
			if( posOriginal.z < 0 && blockVel.z < 0 ) blockVel.z = -blockVel.z;
			if( posOriginal.z < 0 && blockVel.z < 0 ) blockVel.z = -blockVel.z;

			{

			}
			((BlockScript)gb.GetComponent( "BlockScript" )).SetVelocity( blockVel );
			var scale = new Vector3( Random.Range( -.5f, 3.0f ), 0, Random.Range( -.5f, 3.0f ) );
			
			//gb.transform.GetComponent<BlockScript>().SetItem(); 
			gb.transform.localScale += scale;
			
			//		gb.rigidbody.velocity = vel;
			//print ( gb.rigidbody.velocity.x + ", " + gb.rigidbody.velocity.y + ", " + gb.rigidbody.velocity.z );
			
		} 

		
		//gb.transform.Translate (-1 / 60.0f, 0, 0);
		//(gb.GetComponent<BlockScript> () as BlockScript).Blah ();
	}
}
