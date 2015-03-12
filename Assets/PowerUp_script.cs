using UnityEngine;
using System.Collections;

public class PowerUp_script : MonoBehaviour {

	public float time;

	// Use this for initialization
	void Start () {
		time = 10;
		
	}
	
	void OnCollisionEnter(Collision collisionInfo)
	{
		if(collisionInfo.gameObject.name == "Player")
		{
				Destroy (gameObject);
		}
	}
	void FixedUpdate(){
		time -= Time.fixedDeltaTime;
		if (time <= 0) {
			Destroy(gameObject);
		}

	}
	// Update is called once per frame
	void Update () {

	}
}
