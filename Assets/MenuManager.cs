using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	public Menu CurrentMenu;
	public void Start() {
		ShowMenu (CurrentMenu);
	}

	public void ShowMenu(Menu menu) {
		if (CurrentMenu != null)
			CurrentMenu.isOpen = false;

		CurrentMenu = menu;
		CurrentMenu.isOpen = true;
	}

	public void StartGame() {
		Application.LoadLevel(1);
	}

	public void Quit() {
		Application.Quit();
	}
}
