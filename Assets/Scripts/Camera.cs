using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public Transform player;
	public float minY, maxY, minX, maxX;

	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Mathf.Clamp (player.position.x, minX, maxX), Mathf.Clamp (player.position.y, minY, maxY), -10);
		//transform.position = new Vector3 (player.position.x, player.position.y, player.position.z);
	}
}
