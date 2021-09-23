using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    Rigidbody2D rb;

    void Start(){
		rb = GetComponent<Rigidbody2D> ();
	}

    public void OnTriggerEnter2D(Collider2D other){
		if (other.name == "punch") {
			rb.AddForce (new Vector2(100000, 100));
		}
	}
}
