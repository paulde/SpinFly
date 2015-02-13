using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {
	public Texture2D fadeOutTexture;
	public float fadeSpeed = 9999999999999f;

	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDir = -1;

	void OnGUI () {
		alpha += fadeDir * fadeSpeed * Time.deltaTime * .5f;
		alpha = Mathf.Clamp(alpha,0,1);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
	}
	public void FadeIn() {
			alpha = 1.0f;
			fadeDir = -1;
		}
	public void FadeOut() {
		alpha = 0.0f;
		fadeDir = 1;
	}


}
