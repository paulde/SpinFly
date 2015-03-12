using UnityEngine;
using System.Collections;

public class PowerUp_Gen : MonoBehaviour {
	public float timer;
	public float TIME = 1f;
	public float PROBABILITY = 50f;

	// Use this for initialization
	void Start () {
		timer = TIME; //Amount of time between PowerUp chance
	
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {

			float chance = Random.Range (1, 100);
			if (chance <= PROBABILITY) {
				float x = Random.Range (-16, 16);
				float y = 12f;
				float z = Random.Range (-16, 16);

				GameObject powerUp = (GameObject)Instantiate (Resources.Load ("PowerUp"), new Vector3 (x, y, z), Quaternion.identity);
				powerUp.transform.Rotate (new Vector3 (331.5f, 164.06f, 316.75f));

			}
			timer = TIME; //reset time
		}
	
	}
}
