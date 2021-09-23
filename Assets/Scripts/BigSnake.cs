using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSnake : MonoBehaviour {

	public GameObject player;
	Animator animator;
	AudioSource audioSource;

	public float speed;
	public float down;
	public float left;
	public float right;
	public float lifePoint;
	bool trigger = false;
	public bool alive = true;

	void Start(){
		animator = GetComponent<Animator> ();
		audioSource = GetComponent<AudioSource>();
		GameObject scorpion = GameObject.Find("Scorpion");
        Physics2D.IgnoreCollision(scorpion.GetComponent<Collider2D>(), GetComponent<Collider2D> ());
	}

	// Update is called once per frame
	void Update () {
		if (Pause.isPaused == false) {
			animator.enabled = true;
			if (alive) {
				if (player.transform.position.x > transform.position.x) {
					transform.rotation = new Quaternion (0, 180, 0, 0);
				} else {
					transform.rotation = new Quaternion (0, 0, 0, 0);
				}
				if (player.transform.position.x > lifePoint) {
					trigger = true;
				}
				if (trigger) {
					transform.position = new Vector2 (Mathf.Lerp (transform.position.x, player.transform.position.x, speed), transform.position.y);
				}
				transform.position = new Vector2 (Mathf.Clamp (transform.position.x, left, right), transform.position.y);

			} else {
				animator.SetTrigger ("die");
				//transform.rotation = new Quaternion (180, transform.rotation.y, 0, 0);
				GetComponent<BoxCollider2D> ().enabled = false;
				if (transform.position.y > down) {
					transform.position = new Vector3 (transform.position.x, transform.position.y - 0.06f, 0);
				}
			}
		} else {
			animator.enabled = false;
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "punch") {
			alive = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.name == "Player") StartCoroutine(Respawn());
	}

	IEnumerator Respawn(){
		yield return new WaitForSeconds(1);
		trigger = false;
		transform.position = new Vector3(right - 0.3f, transform.position.y, 0);
	}
}
