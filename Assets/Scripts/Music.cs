using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

	public static bool hasMusic = false;

	AudioSource audioSource;

	void Awake(){
		audioSource = GetComponent<AudioSource> ();
		if (!hasMusic) {
			DontDestroyOnLoad (gameObject);
			audioSource.Play ();
		} else {
			Destroy (gameObject);
		}
	}
		
}
