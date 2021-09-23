using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GooglePlayGames;
//using UnityEngine.SocialPlatforms;
//using GooglePlayGames.BasicApi;
using System;

public class GooglePlayGame : MonoBehaviour
{
/*
    public static void Init()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }

    public static void Login(Action<bool> onLogin)
    {

        if (Social.Active == null)
        {
            return;
        }

        if (IsAuthenticated())
        {
            return;
        }
        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.NoPrompt, (result) =>
        {
            onLogin(true);
        });
    }
    public static bool IsAuthenticated()
    {
        return Social.localUser.authenticated;
    }

    public static void IncrementAchievement(string achievement, int points, Action<bool> onIncrementAchievement)
    {

        PlayGamesPlatform.Instance.IncrementAchievement(achievement, points, (bool success) =>
        {
            if (onIncrementAchievement != null)
            {
                onIncrementAchievement(success);
            }

        });

    }

    public static void ReportAchievementProgress(string achievementID, float progress, Action<bool> onIncrementAchievement)
    {

        Social.ReportProgress(achievementID, progress, (bool success) =>
        {

            if (onIncrementAchievement != null)
            {
                onIncrementAchievement(success);
            }

        });

    }

    public static void ShowAchievementsUI(){
		Login(success => {});
		Social.ShowAchievementsUI();
	}*/

}

