using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class ADManager : MonoBehaviour
{
    private string APP_ID = "ca-app-pub-5726234293407359~3678098085";   

    private BannerView bannerAD;
    private InterstitialAd interstitialAd;
    private RewardBasedVideoAd rewardVideoAd;


    void Start()
    {

        // MobileAds.Initialize(APP_ID);
        RequestBanner();
        RequestInterstitial();
        RequestVideoAD();

    }

    void RequestBanner()
    {
        string banner_ID = "ca-app-pub-3940256099942544/6300978111";//"ca-app-pub-5726234293407359/5318003881";
        bannerAD = new BannerView(banner_ID, AdSize.SmartBanner, AdPosition.Bottom);

        // AdRequest adRequest = new AdRequest.Builder().Build();

        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        bannerAD.LoadAd(adRequest);

    }

    void RequestInterstitial()
    {
        string interstitial_ID = "ca-app-pub-3940256099942544/1033173712";//"ca-app-pub-5726234293407359/8874105517";
        interstitialAd = new InterstitialAd(interstitial_ID);

        // AdRequest adRequest = new AdRequest.Builder().Build();
        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        interstitialAd.LoadAd(adRequest);

    }

    void RequestVideoAD()
    {
        string video_ID = "ca-app-pub-3940256099942544/5224354917";//"ca-app-pub-5726234293407359/1988584221";
       rewardVideoAd = RewardBasedVideoAd.Instance;

        // AdRequest adRequest = new AdRequest.Builder().Build();
        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        rewardVideoAd.LoadAd(adRequest, video_ID);

    }


    public void Display_Banner()
    {
        bannerAD.Show();
    }

    public void Display_InterstitialAD()
    {
        if(interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
    }

    public void Display_Reward_Video()
    {
        if(rewardVideoAd.IsLoaded())
        {
            rewardVideoAd.Show();
        }
    }


    //-------------Handle Events------------------


    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Display_Banner();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        RequestBanner();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    void HandleBannerADEvents(bool subscribe)
    {
        if(subscribe)
        {
            // //this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
            // // Called when an ad request has successfully loaded.
            // this.bannerAD.OnAdLoaded += this.HandleOnAdLoaded;
            // // Called when an ad request failed to load.
            // this.bannerAD.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
            // // Called when an ad is clicked.
            // this.bannerAD.OnAdOpening += this.HandleOnAdOpened;
            // // Called when the user returned from the app after an ad click.
            // this.bannerAD.OnAdClosed += this.HandleOnAdClosed;
            // // Called when the ad click caused the user to leave the application.
            // this.bannerAD.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
        }
        else
        {
        //     //this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // // Called when an ad request has successfully loaded.
        // this.bannerAD.OnAdLoaded -= this.HandleOnAdLoaded;
        // // Called when an ad request failed to load.
        // this.bannerAD.OnAdFailedToLoad -= this.HandleOnAdFailedToLoad;
        // // Called when an ad is clicked.
        // this.bannerAD.OnAdOpening -= this.HandleOnAdOpened;
        // // Called when the user returned from the app after an ad click.
        // this.bannerAD.OnAdClosed -= this.HandleOnAdClosed;
        // // Called when the ad click caused the user to leave the application.
        // this.bannerAD.OnAdLeavingApplication -= this.HandleOnAdLeavingApplication;
        }
        
    }

    void OnEnable()
    {
        HandleBannerADEvents(true);
    }

    void OnDisable()
    {
        HandleBannerADEvents(false);
    }


    // ------------------------------------Handle Events for Reward Video--------------------------


    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        Display_Reward_Video();
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        RequestVideoAD();
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        scoreManager.RewardScore();
        // string type = args.Type;
        // double amount = args.Amount;
        // MonoBehaviour.print(
        //     "HandleRewardBasedVideoRewarded event received for "
        //                 + amount.ToString() + " " + type);
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }


    void HandleRewardVideoADEvents(bool subscribe)
    {
        if(subscribe)
        {
            // Called when an ad request has successfully loaded.
        rewardVideoAd.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardVideoAd.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardVideoAd.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardVideoAd.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardVideoAd.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardVideoAd.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardVideoAd.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
            
        }
        else
        {
            // Called when an ad request has successfully loaded.
        rewardVideoAd.OnAdLoaded -= HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardVideoAd.OnAdFailedToLoad -= HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardVideoAd.OnAdOpening -= HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardVideoAd.OnAdStarted -= HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardVideoAd.OnAdRewarded -= HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardVideoAd.OnAdClosed -= HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardVideoAd.OnAdLeavingApplication -= HandleRewardBasedVideoLeftApplication;
        }
    }


    void OnEnabled()
    {
        HandleRewardVideoADEvents(true);
    }

    void OnDisabled()
    {
        HandleRewardVideoADEvents(false);
    }

}