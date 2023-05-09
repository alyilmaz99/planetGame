using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using System;
using TMPro;

public class ADManager : MonoBehaviour
{
    [SerializeField] private PlayerControl playerControl;
    [SerializeField] private GameManager gameManager;
    private RewardedAd rewardedAd;
    [SerializeField] private bool adCheck = false;
    [SerializeField] private string adUnityId= "ca-app-pub-2763655103678935/6187843678";


    [SerializeField] private int noadsCheck;


    [Header("buttons close")]
    [SerializeField] private GameObject scoreGameObject;
    [SerializeField] private GameObject pauseButton;

    [Obsolete]
    void Start()
    {

        MobileAds.Initialize(initStatus => { });

        RequestRewardedVideo();


        noadsCheck = PlayerPrefs.GetInt("noads");






        

    }
    [Obsolete]
    private void Reborn(object sender, Reward e)
    {
        Debug.Log("yeniden dogdu");
        pauseButton.SetActive(true);
        scoreGameObject.SetActive(true);

        playerControl.Reborn();
        playerControl.endCheck = false;
        adCheck = false;
        
        Time.timeScale = 1;

        if (this.rewardedAd != null)
        {
            this.rewardedAd.Destroy();
            Debug.Log("reklam temizlendi");
            Debug.Log("reklam isteniyor");
            RequestRewardedVideo();
        }

    }
    [Obsolete]
    void Update()
    {
       
    }


    [Obsolete]
    public void RequestRewardedVideo()
    {
        if (this.rewardedAd != null)
        {
            this.rewardedAd.Destroy();

        }

        Debug.Log("reklam yüklüyo");
        string adUnitId;
#if UNITY_ANDROID
        adUnitId = "ca-app-pub-2763655103678935/6187843678";
        

#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            adUnitId = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(adUnitId);
        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += Reborn;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
        if (this.rewardedAd.IsLoaded())
        {
            Debug.Log("loaded");
        }

        else { Debug.Log("not loaded"); }
    }




    [Obsolete]

    void WatchAd()
    {
        

        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }
    [Obsolete]
    public void WatchRebornAd()
    {
        if (noadsCheck == 1)
        {
            Debug.Log("yeniden dogdu");
            pauseButton.SetActive(true);
            scoreGameObject.SetActive(true);
            playerControl.Reborn();
            playerControl.endCheck = false;
            Time.timeScale = 1;
        }
        else {
            if (!adCheck)
            {
                WatchAd();
                adCheck = true;
            }
        }
        
        
        
    }
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        Debug.Log("reward");
    }



}