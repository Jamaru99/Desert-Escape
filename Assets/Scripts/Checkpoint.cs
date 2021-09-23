using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public byte index;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			Player.checkpointCount = index;
		}
	}
}
