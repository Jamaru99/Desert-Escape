using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	GameObject music;
	GameObject player;

	void OnMouseDown () {
		transform.localScale *= 0.9f;
		music = GameObject.FindGameObjectWithTag ("Music");
		//if (Player.lives != 0) {
			//player = GameObject.FindGameObjectWithTag ("Player");
			//PlayerPrefs.SetFloat ("PosX", player.transform.position.x);
			//PlayerPrefs.SetFloat ("PosY", player.transform.position.y);
		//}
	}
	
	// Update is called once per frame
	void OnMouseUp () {
		Destroy (music);
		SceneManager.LoadScene (0);
		Pause.isPaused = false;
		Player.talking = false;
		NewGame.banner.Hide ();
	}
}
