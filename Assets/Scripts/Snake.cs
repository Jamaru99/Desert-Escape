using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {

	public GameObject snakeBody;
	GameObject player;
	Animator animator;

	public float speed;
	public float left;
	public float right;
	public float down;
	bool alive = true;
	bool aux = true;

	void Start(){
		animator = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Pause.isPaused == false) {
			animator.enabled = true;
			if (alive) {
				if (transform.position.x > right) {
					aux = true;
					transform.rotation = new Quaternion (0, 0, 0, 0);
				} 
				if (transform.position.x < left) {
					aux = false;
					transform.rotation = new Quaternion (0, 180, 0, 0);
				}
				if (aux) {
					transform.position = new Vector2 (transform.position.x - speed, transform.position.y);
				} else {
					transform.position = new Vector2 (transform.position.x + speed, transform.position.y);
				}
			} else {
				animator.SetTrigger ("die");
				transform.parent = null;
				transform.rotation = new Quaternion (180, transform.rotation.y, 0, 0);
				snakeBody.GetComponent<BoxCollider2D> ().enabled = false;
				if (transform.position.y > down) {
					transform.position = new Vector3 (transform.position.x, transform.position.y - speed, 1);
				}
			}
		} else {
			animator.enabled = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			player.GetComponent<Rigidbody2D> ().AddForce (new Vector2(0, 425));
			GetComponent<AudioSource> ().Play ();
			GetComponent<CircleCollider2D> ().enabled = false;
			alive = false;
		}

        if (other.gameObject.tag == "Cacto")
        {
			GameObject scorpion = GameObject.Find("Scorpion");
            Physics2D.IgnoreCollision(scorpion.GetComponent<Collider2D>(), snakeBody.GetComponent<Collider2D> ());
			Physics2D.IgnoreCollision(scorpion.GetComponent<Collider2D>(), GetComponent<Collider2D> ());
        }
	
	}
}
