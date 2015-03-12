using UnityEngine;
using System.Collections;

public class Height_Plane_Script : MonoBehaviour {

	public GameObject player;
	public GameObject height_plane;
    public Object pillars;


	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		height_plane = GameObject.Find("Height_Plane");



	}
	
	// Update is called once per frame
	void Update () {

		height_plane.transform.position = new Vector3( player.transform.position.x, player.transform.position.y - 0.2f , player.transform.position.z );
		
		GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("radar");
		foreach (GameObject go in gos) {
			Object.Destroy( go );

		}


        gos = GameObject.FindGameObjectsWithTag("Block");
        Vector3 position = player.transform.position;
        foreach (GameObject go in gos) {
        	Vector3 diff = go.transform.position - position;
        	diff.y = 0;
            float distance = diff.sqrMagnitude;

        	if ( distance < 40)
        	{
	        	GameObject highlight = Instantiate(Resources.Load("Block_Highlight", typeof(GameObject))) as GameObject;
	       		highlight.transform.position = new Vector3(go.transform.position.x, player.transform.position.y+ 0.05f, go.transform.position.z);
	       		highlight.transform.localScale = new Vector3( go.transform.lossyScale.x * 0.004588511469f * 0.2f + 0.03f, 0.1f, go.transform.lossyScale.z * 0.004588511469f  * 0.2f+ 0.05f);

	       		//add change ot color to the detection squares
	       		float height_color = Mathf.Abs(player.transform.position.y - (go.transform.position.y + 15f));
	      		//print(height_color);
	       		highlight.renderer.material.color = new Color (1, 0, 0);
       		}
       		


        }
	}
 

}
