using UnityEngine;
using System.Collections;

public class Net_script : MonoBehaviour {

	public GameObject player;
	private ballscript otherScript;

	// Use this for initialization
	void Start () {
		
		player = GameObject.Find("Player");
		otherScript = player.GetComponent<ballscript> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (otherScript.net_isOn == false) {
			Destroy(gameObject);
		}
	}
}
