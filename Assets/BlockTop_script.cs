using UnityEngine;
using System.Collections;

public class BlockTop_script : MonoBehaviour {
	public Vector3 vel;
	public float speed;

	public bool isBonus;

	public GameObject player;
	private ballscript otherScript;

	// Use this for initialization
	void Start () {
		//vel = Vector3.zero;
		GameObject parent = transform.parent.gameObject;
		vel = parent.GetComponent<BlockScript> ().vel;
		speed = parent.GetComponent<BlockScript> ().speed;

		player = GameObject.Find("Player");
		otherScript = player.GetComponent<ballscript> ();

		//Determine if block is a bonus block
		int randNum = Random.Range (1, 3);
		if (randNum == 1) 
		{
			isBonus = true;
		}

		//renderer.enabled = false;
	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		if(collisionInfo.gameObject.name == "Player")
		{
			for(int i = 0; i < transform.childCount;i++)
			{
				transform.GetChild(i).gameObject.renderer.enabled = false;
			}
			
		}
		if(isBonus == true && collisionInfo.gameObject.name == "Player"){
			isBonus = false;
			if(otherScript.goalMet != true){
				otherScript.score += 1;
			}
			
			
		}
		
	}
	void OnCollisionStay(Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "Player") {
			isBonus = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
