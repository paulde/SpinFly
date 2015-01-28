using UnityEngine;
using System.Collections;

public class Item1Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter( Collider c )
	{
		if (c.tag == "Player") {
			Destroy( gameObject );
			print ( "right hereeee" );
				}
	}
}
