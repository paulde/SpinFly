using UnityEngine;
using System.Collections;

public class minimap_script : MonoBehaviour {

	bool toggle;

	// Use this for initialization
	void Start () {
		toggle = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.M)) 
		{
			toggle = !toggle;
			if (toggle == true) {
				camera.depth = 1;
			} else {
				camera.depth = -2;
			}
		}

	}
}
