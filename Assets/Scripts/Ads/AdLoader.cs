using GoogleMobileAds.Api;
using UnityEngine;

public class AdLoader : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd _interstitial;
    RewardedAd rewardedAd;
    public string adUnitID;
    private float timead = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) => 
        {
            //
        });

        this.RequestBanner();
        LoadAd();

    }

    // Update is called once per frame
    void Update()
    {
        //timead += Time.deltaTime;
        //if (timead >= 3 && timead < 6)
        //{
        //    LoadAd();
        //}
    }

    private void RequestBanner()
    {
        string adUnitID = "ca-app-pub-3940256099942544/6300978111";

        Debug.Log("Requesting Banner Ad");

        if (bannerView != null)
        {
            DestroyAd();
        }

        bannerView = new BannerView(adUnitID, AdSize.Banner, AdPosition.Bottom);
    }

    public void DestroyAd()
    {
        if (bannerView != null)
        {
            Debug.Log("Destroying Banner Ad");
            bannerView.Destroy();
            bannerView = null;
        }
    }

    public void LoadAd()
    {
        if (bannerView == null)
        {
            if (bannerView != null)
            {
                DestroyAd();
            }
            bannerView = new BannerView(adUnitID, AdSize.Banner, AdPosition.Bottom);
        }

        var adRequest = new AdRequest();
        Debug.Log("Loading Banner Ad");
        bannerView.LoadAd(adRequest);
    }

    private void RequestReward()
    {        
        string adUnitID = "";

        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }
        Debug.Log("Requesting Rewarded Ad");

        var adRequest = new AdRequest();

        RewardedAd.Load(adUnitID, adRequest, (RewardedAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                Debug.LogError("Rewarded ad failed to load an ad with error: " + error);
                return;
            }

            Debug.Log("Rewarded ad loaded with response: " + ad.GetResponseInfo());
            rewardedAd = ad;
        });
    }

    public void ShowRewardAd()
    {
        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {
                Debug.Log("User earned reward: " + reward.Amount);
            });
        }
    }
}
