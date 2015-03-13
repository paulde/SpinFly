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

	void OnTriggerEnter(Collider collisionInfo)
	{
		if(collisionInfo.tag == "Player")
		{
			for(int i = 0; i < transform.childCount;i++)
			{
				transform.GetChild(i).gameObject.renderer.enabled = false;
			}
			
		}
		if(isBonus == true && collisionInfo.tag == "Player"){
			isBonus = false;
			if(otherScript.goalMet != true){
				otherScript.score += 1;
			}
			
			
		}
		
	}
	void OnTriggerStay(Collider collisionInfo)
	{
		if (collisionInfo.tag == "Player") {
			isBonus = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(otherScript.goalMet == true)
		{
			for(int i = 0; i < transform.childCount;i++)
			{
				transform.GetChild(i).gameObject.renderer.enabled = false;
			}
			
		}
	}
}
