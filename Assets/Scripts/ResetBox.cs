using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetBox : MonoBehaviour
{
    void OnMouseUp(){
        if(gameObject.name == "sim"){
            Player.checkpointCount = 0;
		    NewGame.banner.Hide ();
		    Player.lives = 20;
		    PlayerPrefs.SetInt ("Lives", Player.lives);
		    Player.level = 1;
		    PlayerPrefs.SetInt ("FaseSalva", Player.level);
		    //PlayerPrefs.SetFloat ("PosX", -6.97f);
		    //PlayerPrefs.SetFloat ("PosY", -0.8f);
		    SceneManager.LoadScene (1);
        }
        else {
            GameObject.Find("resetbox").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("sim").GetComponent<BoxCollider2D>().enabled = false;
			GameObject.Find("nao").GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
