using UnityEngine;
using System.Collections;

public class game_menu_script : MonoBehaviour {
	public GUISkin gSkin;

	void OnGUI() {
		GUI.skin = gSkin;

		float xCenter = (Screen.width / 2) - (Screen.width * 0.08f);
		float yCenter = (Screen.height / 2) - (Screen.height * 0.2f);
		float button_width = Screen.width * 0.2f;
		float button_height = Screen.height * 0.1f;
		float yOffset = Screen.height * 0.15f;

		if(GUI.Button (new Rect( xCenter, yCenter, button_width, button_height), "Start") )
		{
			Application.LoadLevel(1);
		}

		if(GUI.Button (new Rect( xCenter, yCenter + yOffset, button_width, button_height), "Settings") )
		{
			Application.LoadLevel(1);
		}

		if(GUI.Button (new Rect( xCenter, yCenter + (yOffset * 2), button_width, button_height), "Quit") )
		{
			Application.Quit();
		}
	}
}
