﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//var v = new Vector3( 0, 
		GameObject playerObj = GameObject.Find ("Player");
		//var v = new Vector3 (playerObj.transform.position.x + playerObj.rigidbody.velocity.x, transform.position.y, playerObj.transform.position.z 
		 //                    + playerObj.rigidbody.velocity.z );

	//	var v = new Vector3 (playerObj.transform.position.x, transform.position.y, playerObj.transform.position.z - 5 );
		var y = playerObj.transform.position.y + 25;
		//if( y < 20 )
	//		y = 20;
		Vector3 v;

		if(Input.GetButton("Fire1")) 
		{
			v = new Vector3 (0,100,0);
			transform.position = v;
			Vector3 origin = new Vector3(0,0,0);
		       	transform.LookAt(origin);
		}
		else
		{
			v = new Vector3 (playerObj.transform.position.x, y, playerObj.transform.position.z );
			transform.position = v;
			transform.LookAt (playerObj.transform.position);
		}

		            	//;

			//transform.position.z = ;
	}
}
