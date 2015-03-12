using UnityEngine;
using System.Collections;

public class MenuCam_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (Vector3.zero, Vector3.up, 1 * Time.deltaTime);
		transform.RotateAround (Vector3.zero, Vector3.left, 1 * Time.deltaTime);
		transform.LookAt (Vector3.zero);

	}
}
