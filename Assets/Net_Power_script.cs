using UnityEngine;
using System.Collections;

public class Net_Power_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Color col = renderer.material.color;
		col.a = 1;
		renderer.material.color = col;

	
	}

	void FixedUpdate() {
		Color col = renderer.material.color;
		col.a -= Time.deltaTime * .1f;
		renderer.material.color = col;

		if (renderer.material.color.a <= 0) {
			Destroy(gameObject);
		}


	}
	void OnCollisionEnter(Collision collisionInfo)
	{
		if(collisionInfo.gameObject.name == "Player")
		{
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {

	
	}
}
