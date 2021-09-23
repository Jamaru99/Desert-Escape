using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorpion : MonoBehaviour {

	GameObject player;
	Animator animator;
	Rigidbody2D rb;
	AudioSource audioSource;

	public float speed;
	public float left;
	public float right;
	int life = 30;
	bool alive = true;
	bool aux = true;

	void Start(){
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource>();
		player = GameObject.FindGameObjectWithTag ("Player");
		GameObject cacto = GameObject.Find("cacto");
        Physics2D.IgnoreCollision(cacto.GetComponent<Collider2D>(), GetComponent<Collider2D> ());
		GameObject sb = GameObject.Find("snake_body");
		Physics2D.IgnoreCollision(sb.GetComponent<Collider2D>(), GetComponent<Collider2D> ());
		GameObject sb2 = GameObject.Find("snake_body2");
		Physics2D.IgnoreCollision(sb2.GetComponent<Collider2D>(), GetComponent<Collider2D> ());
		GameObject sb3 = GameObject.Find("snake_body3");
		Physics2D.IgnoreCollision(sb3.GetComponent<Collider2D>(), GetComponent<Collider2D> ());
	}

	// Update is called once per frame
	void Update () {
		if(!alive) StartCoroutine(Die());
		if (Pause.isPaused == false) {
			
			animator.enabled = true;
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

			if (transform.position.x - player.transform.position.x < 2 && transform.position.x - player.transform.position.x > -2 &&
			    transform.position.y - player.transform.position.y > -3 && transform.position.y - player.transform.position.y < 3) {
				//animator.SetBool ("attack", true);
			} else {
				//animator.SetBool ("attack", false);
			}
			
		} else {
			animator.enabled = false;
		}
	
	}

	public void OnTriggerEnter2D(Collider2D other){
		if (other.name == "punch") {
			life -= 1;
			rb.AddForce (new Vector2(300, 0));
			if(life == 0) alive = false;
			audioSource.Play();
		}
	}

	IEnumerator Die(){
		GetComponent<BoxCollider2D>().enabled = false;
		transform.localScale *= 0.98f;
		transform.rotation = new Quaternion(0,0,90,0);
		//GooglePlayGame.ReportProgressAchievements("CgkI1Yqy4v0CEAIQAA", 100.0f,(bool success) => {});
		yield return new WaitForSeconds(0.1f);
	}

	
		
}
