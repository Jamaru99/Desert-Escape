using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class NewGame : MonoBehaviour {

	public static BannerView banner;

	void Start(){
		//GooglePlayGame.Init();
		//GooglePlayGame.Login((bool success) => {});
		RequestBanner ();
		if (PlayerPrefs.HasKey ("Lives")) {
			Player.lives = (byte) PlayerPrefs.GetInt ("Lives");
		}
	}


	void OnMouseDown(){
		transform.localScale *= 0.9f;
		Music.hasMusic = false;
	}

	void OnMouseUp(){
		transform.localScale /= 0.9f;
		if(PlayerPrefs.HasKey("FaseSalva")){
			GameObject.Find("resetbox").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("sim").GetComponent<BoxCollider2D>().enabled = true;
			GameObject.Find("nao").GetComponent<BoxCollider2D>().enabled = true;
		} else{
			Player.checkpointCount = 0;
		    banner.Hide ();
		    Player.lives = 20;
		    PlayerPrefs.SetInt ("Lives", Player.lives);
		    Player.level = 1;
		    PlayerPrefs.SetInt ("FaseSalva", Player.level);
		    //PlayerPrefs.SetFloat ("PosX", -6.97f);
		    //PlayerPrefs.SetFloat ("PosY", -0.8f);
		    SceneManager.LoadScene (1);
		}
	}


	public static void RequestBanner(){
		banner = new BannerView ("ca-app-pub-1541045839364233/7520225311", AdSize.Banner, AdPosition.Bottom);
		banner.LoadAd(new AdRequest.Builder().Build());
		banner.Show ();
	}
}
