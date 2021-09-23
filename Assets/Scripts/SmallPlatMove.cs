using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPlatMove : MonoBehaviour {

	public GameObject player;

	public float speed;
	public float up;
	public float down;
	public float right;
	public float left;

	bool aux = true;

	// Update is called once per frame
	void Update () {
		if (Pause.isPaused == false) {
			if (right == 0 && left == 0) {
				if (transform.position.y > up) {
					aux = true;
				} 
				if (transform.position.y < down) {
					aux = false;
				}
				if (aux) {
					transform.position = new Vector2 (transform.position.x, transform.position.y - speed);
				} else {
					transform.position = new Vector2 (transform.position.x, transform.position.y + speed);
				}
			}
			if (up == 0 && down == 0) {
				if (transform.position.x > right) {
					aux = true;
				} 
				if (transform.position.x < left) {
					aux = false;
				}
				if (aux) {
					transform.position = new Vector2 (transform.position.x - speed, transform.position.y);
				} else {
					transform.position = new Vector2 (transform.position.x + speed, transform.position.y);
				} 
			}
		} 
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			player.transform.parent = transform;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			player.transform.parent = null;
		}
	}
}
