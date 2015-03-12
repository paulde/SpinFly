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
			
			
				gb = (GameObject)Instantiate (Resources.Load ("pillar_prefab"), posOriginal, Quaternion.identity);
				((BlockScript)gb.GetComponent( "BlockScript" )).SetVelocity( new Vector3( Random.Range( -1.0f, 1.0f ), 0, Random.Range( -1.0f, 1.0f ) ) );
			var scale = new Vector3( Random.Range( -.5f, 3.0f ), 0, Random.Range( -.5f, 3.0f ) );
			

				gb.transform.localScale += scale;
			

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

			float x = 0; 
			float z = 0;
			

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
		
			var posOriginal = new Vector3 (Mathf.Cos (angle) * start, Random.Range( 3.0f, 9.0f ) , Mathf.Sin (angle) * start);

			var rot = Quaternion.Euler( 0, Random.Range( 0.0f, 90.0f ), 0 );
			gb = (GameObject)Instantiate (Resources.Load ("pillar_prefab"), posOriginal, Quaternion.identity);
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

			gb.transform.localScale += scale;
			
	
			
		} 

		

	}
}
