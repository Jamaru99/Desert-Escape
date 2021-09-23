using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	Animator animator;
	AudioSource audioSource;
	Rigidbody2D rb;
	public TextMesh lifeCounter;
	public GameObject heart;
	public GameObject punch;

	public static byte level = 1;
	public static byte checkpointCount = 0;
	public static byte lives;
	public static bool talking = false;
	public float speed;
	public bool onGround = true;
	public bool isJumping = false;

	float up = 0.3f, x, y;
	short w, h;
	bool f;

	void Start () {
		animator = GetComponent<Animator> ();
		audioSource = GetComponent<AudioSource> ();
		rb = GetComponent<Rigidbody2D> ();
		if (PlayerPrefs.HasKey ("FaseSalva")) {
			level = (byte) PlayerPrefs.GetInt ("FaseSalva");
		}

		lifeCounter.text = "x" + lives;
		GameObject pointerR = GameObject.Find("RightArrow"), pointerL = GameObject.Find("LeftArrow");
        Vector3 pointerPos = UnityEngine.Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/7, Screen.height/7, -1));
        pointerR.transform.position = new Vector3(pointerPos.x + 1, pointerR.transform.position.y, -6);
        pointerL.transform.position = new Vector3(pointerPos.x - 1, pointerL.transform.position.y, -6);

	}

	void Update () {
		GameObject[] musics = GameObject.FindGameObjectsWithTag ("Music");
		if(musics.Length > 1)
		{
			Destroy(musics[1]);
		}
		if (Pause.isPaused == false) {
			animator.enabled = true;
			if (talking == false) {

				if(onGround) animator.SetBool ("isJumping", false);
					
				if (isJumping) { //Bloco de código para pular
					transform.position = new Vector2 (transform.position.x, transform.position.y + up);
					animator.SetBool ("isJumping", true);
					if (up > 0.2f) {
						up -= 0.01f;
					} else if (up > 0.1f) {
						up -= 0.0075f;
					} else if (up > 0) {
						up -= 0.005f;
					}
					if (up <= 0) {
						up = 0.3f;
						isJumping = false;
					}
				}

				if (Input.GetMouseButton (0)) {
					for (int i = 0; i < Input.touchCount; i++) {
						if (Input.GetTouch (i).position.x < w/3 && Input.GetTouch (i).position.x > w/7 && Input.GetTouch (i).position.y < h/7) {
							transform.position = new Vector2 (Mathf.Clamp (transform.position.x + 0.115f, -8.3f, 134), transform.position.y);
							transform.rotation = new Quaternion (0, 0, 0, 0);
							animator.SetBool ("isMoving", true);
							NewGame.banner.Hide ();
						}
						if (Input.GetTouch (i).position.x < w/7 && Input.GetTouch (i).position.y < h/7) {
							transform.position = new Vector2 (Mathf.Clamp (transform.position.x - 0.115f, -8.3f, 134), transform.position.y);
							transform.rotation = new Quaternion (0, 180, 0, 0);
							animator.SetBool ("isMoving", true);
						}
						if (onGround && Input.GetTouch (i).position.x > 3 * w/4 && Input.GetTouch (i).position.y < h/7) {
							isJumping = true;
						}
						if (Input.GetTouch (i).position.y > h / 7) 
							StartCoroutine (Punch ());
					}
				}
				
				if (Input.GetMouseButtonUp (0)) {
					animator.SetBool ("isMoving", false);
				}

				if (transform.position.y < -5) {
					StartCoroutine (Die ());
				}
			} else {
				animator.SetBool ("isMoving", false);
				animator.SetBool ("isJumping", false);
			}

		} else {
			animator.enabled = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Finish") {
			GetComponent<BoxCollider2D> ().enabled = false;
			checkpointCount = 0;
			if(f) level += 1;
			f = false;
			Music.hasMusic = true;
			PlayerPrefs.SetInt ("FaseSalva", level);
			//PlayerPrefs.SetFloat ("PosX", -6.97f);
			//PlayerPrefs.SetFloat ("PosY", -0.8f);
			SceneManager.LoadScene (level);
		}
		if (other.tag == "Ground") {
			f = true;
			onGround = true;
			w = (short) Screen.width;
			h = (short) Screen.height;
		}
		if (other.tag == "Heart") {
			lives += 1;
			heart.GetComponent<AudioSource> ().Play ();
			lifeCounter.text = "x" + lives;
			PlayerPrefs.SetInt ("Lives", lives);
			Destroy (heart);
		}
		if (other.tag == "Car") {
			rb.AddForce(new Vector2(0, 800));
		}
		if (other.name == "suco") {
			SceneManager.LoadScene("Fim");
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Cacto") {
			StartCoroutine (Die ());
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Ground") {
			onGround = false;
		}
	}

	IEnumerator Punch(){
		animator.SetBool ("isPunching", true);
		yield return new WaitForSeconds (0.2f);
		punch.GetComponent<SpriteRenderer>().enabled = true;
		punch.GetComponent<CircleCollider2D> ().enabled = true;
		if(transform.rotation.y == 0) punch.transform.position = new Vector2 (punch.transform.position.x + 0.48f, punch.transform.position.y);
		else punch.transform.position = new Vector2 (punch.transform.position.x - 0.48f, punch.transform.position.y);
		yield return new WaitForSeconds (0.2f);
		animator.SetBool ("isPunching", false);
		punch.GetComponent<CircleCollider2D> ().enabled = false;
		punch.GetComponent<SpriteRenderer>().enabled = false;
		punch.transform.position = new Vector2(transform.position.x, transform.position.y + 0.2f);
	}

	IEnumerator Die(){
		Pause.isPaused = true;
		audioSource.Play ();
		yield return new WaitForSeconds (1);
		Pause.isPaused = false;
		animator.SetBool ("isMoving", false);
		Scene s = SceneManager.GetActiveScene ();
		if(s.name != "Level_2" && s.name != "Level_5" && s.name != "Level_4" && s.name != "Level_6" && s.name != "Level_11" && s.name != "Level_6") lives -= 1;
		lifeCounter.text = "x" + lives;
		PlayerPrefs.SetInt ("Lives", lives);
		if (lives <= 0) {
			Destroy (GameObject.FindGameObjectWithTag ("Music"));
			SceneManager.LoadScene ("GameOver");
		} else {
			switch (checkpointCount) {
			case 0:
				transform.position = new Vector2 (-6.97f, -0.8f);
				break;
			case 1:
				transform.position = new Vector2 (50.92f, -2.09f);
				break;
			case 2:
				transform.position = new Vector2 (39, 2.1f);
				break;
			case 3:
				transform.position = new Vector2 (99.35f, 5.19f);
				break;
			case 4:
				transform.position = new Vector2 (79.71f, 2.17f);
				break;
			case 5:
				transform.position = new Vector2 (60.82f, 3.9f);
				break;
			}
		}
	}
}
