using UnityEngine;
using System.Collections;

public class bonus_script : MonoBehaviour {
	public GameObject parent;
	private BlockTop_script otherScript;

	// Use this for initialization
	void Start () {
		parent = transform.parent.gameObject;
		otherScript = parent.GetComponent<BlockTop_script> ();
		if(!otherScript.isBonus)
		{
			renderer.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (renderer.enabled == true) {
			Vector3 parentPos = transform.parent.gameObject.transform.parent.gameObject.transform.localPosition;
			Vector3 platform = new Vector3 (parentPos.x, parentPos.y+15, parentPos.z);
			transform.position = platform;
		}
	}
}
