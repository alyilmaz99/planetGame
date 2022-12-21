using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using System;

public class ADManager : MonoBehaviour
{
    [SerializeField] private PlayerControl playerControl;
    [SerializeField] private GameManager gameManager;
    private RewardedAd rewardedAd;
    [SerializeField] private bool adCheck = false;
    [SerializeField] private string adUnityId="";


    [SerializeField] private int noadsCheck;

    void Start()
    {


        noadsCheck= PlayerPrefs.GetInt("noads");


#if UNITY_ANDROID
        adUnityId = "ca-app-pub-3940256099942544/5354046379";
#endif

        

        

    }

    private void Reborn(object sender, Reward e)
    {
        Debug.Log("yeniden dogdu");
        
        playerControl.Reborn();
        playerControl.endCheck = false;
        adCheck = false;
        Time.timeScale = 1;
    }

    void Update()
    {

    }

    void WatchAd()
    {
        if (this.rewardedAd != null)
        {
            this.rewardedAd.Destroy();

        }
        this.rewardedAd = new RewardedAd(adUnityId);
        this.rewardedAd.OnUserEarnedReward += Reborn;
        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);

        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }

    public void WatchRebornAd()
    {
        if (noadsCheck == 1)
        {
            Debug.Log("yeniden dogdu");

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

    public void RequestAndLoadAD()
    {
        
    }




}