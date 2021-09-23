using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour {

	void OnMouseDown(){
		transform.localScale *= 0.9f;
		Music.hasMusic = false;
	}

	void OnMouseUp(){
		NewGame.banner.Hide ();
		Player.checkpointCount = 0;
		transform.localScale /= 0.9f;
		if (Player.lives > 0) {
			SceneManager.LoadScene (PlayerPrefs.GetInt ("FaseSalva"));
		}
	}
}
