using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	public Sprite play;
	public Sprite pause;
	public GameObject menu;
	public static bool isPaused = false;

	void OnMouseDown(){
		isPaused = !isPaused;
		if (isPaused == true) {
			GetComponent<SpriteRenderer> ().sprite = play;
			menu.SetActive (true);
			NewGame.banner.Show ();
		} else {
			GetComponent<SpriteRenderer> ().sprite = pause;
			menu.SetActive (false);
			NewGame.banner.Hide ();
		}

	}
}
