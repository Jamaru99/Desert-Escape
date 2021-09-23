using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsAbout : MonoBehaviour {

	void OnMouseDown () {
		transform.localScale *= 0.9f;
	}
	
	void OnMouseUp(){
		SceneManager.LoadScene ("Sobre");
	}
}
