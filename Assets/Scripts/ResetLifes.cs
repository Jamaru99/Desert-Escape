using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;
using UnityEngine.SceneManagement;

public class ResetLifes : MonoBehaviour
{

    RewardBasedVideoAd rbva;
    string adId = "ca-app-pub-1541045839364233/5204855105";

    void Start()
    {
        if (Player.lives >= 20)
            Destroy(gameObject);
        rbva = RewardBasedVideoAd.Instance;
        rbva.OnAdRewarded += HandleRewardBasedVideoRewarded;
        rbva.OnAdClosed += HandleAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        rbva.LoadAd(request, adId);
    }

    public void HandleAdClosed(object sender, EventArgs args)
    {
        AdRequest request = new AdRequest.Builder().Build();
        rbva.LoadAd(request, adId);
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        Player.lives = 20;
        PlayerPrefs.SetInt("Lives", (int)Player.lives);
        if (SceneManager.GetActiveScene().name == "GameOver") {
            SceneManager.LoadScene(PlayerPrefs.GetInt("FaseSalva"));
        }
    }

    void OnMouseDown()
    {
        transform.localScale *= 0.9f;
    }

    void OnMouseUp()
    {
        if (rbva.IsLoaded())
            rbva.Show();
        transform.localScale /= 0.9f;
    }

}
