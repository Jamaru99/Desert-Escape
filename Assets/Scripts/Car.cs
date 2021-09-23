using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

	public float speed;
	
	// Update is called once per frame
	void Update () {
		if (Pause.isPaused == false) {
			transform.position = new Vector2 (transform.position.x - speed, transform.position.y);
			if (transform.position.x < -13) {
				transform.position = new Vector2 (54, transform.position.y);
			}
		}
	}
		
}
