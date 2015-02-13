using UnityEngine;
using System.Collections;

public class bonus_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(transform.parent.gameObject.tag != "Bonus")
		{
			renderer.enabled = false;
		}

	
	}
	
	// Update is called once per frame
	void Update () {
		if (renderer.enabled == true) {
			Vector3 parentPos = transform.parent.transform.localPosition;
			Vector3 platform = new Vector3 (parentPos.x, parentPos.y, parentPos.z);
			transform.position = platform;
		}
	
	}
}
