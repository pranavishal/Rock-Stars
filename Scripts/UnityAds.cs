using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour
{
    string googlePlayID = "4048966";
    string appleStoreID = "4048967";

    private string intersitialADAndroid = "Interstitial_Android";
    private string intersitialAdApple = "Interstitial_iOS";

    private string rewardedAdAndroid = "Rewarded_Android";
    private string rewardedAdApple = "Rewarded_iOS";
    //hi
    public bool isTargetPlayStore;
    private bool isTestAd = true;

    bool gameMode = true;
    // Start is called before the first frame update
    void Start()
    {
        InitializeAdvertisements();
    }

    void InitializeAdvertisements()
    {
        if (isTargetPlayStore)
        {
            Advertisement.Initialize(googlePlayID, isTestAd);
            return;
        }

        Advertisement.Initialize(appleStoreID, isTestAd);

    }

    // Update is called once per frame
    public void ShowInstitualAD()
    {
        if (isTargetPlayStore)
        {
            if (!Advertisement.IsReady(intersitialADAndroid))
            {
                return;
            }
            Advertisement.Show(intersitialADAndroid);
        }
        else
        {
            if (!Advertisement.IsReady(intersitialAdApple))
            {
                return;
            }
            Advertisement.Show(intersitialAdApple);
        }
        
    }

    public void ShowInstitualAdReplay()
    {
        
        if (isTargetPlayStore)
        {
            if (!Advertisement.IsReady(intersitialADAndroid))

            {
                return;
            }

            int showAd = Random.Range(1, 4);
            if (showAd == 1)
            {
                Advertisement.Show(intersitialADAndroid);
            }


        }
        else
        {
            if (!Advertisement.IsReady(intersitialAdApple))

            {
                return;
            }

            int showAd = Random.Range(1, 4);
            if (showAd == 1)
            {
                Advertisement.Show(intersitialAdApple);
            }
        }
    }

    public void ShowRewardedAd()
    {
        if (isTargetPlayStore)
        {
            if (!Advertisement.IsReady(rewardedAdAndroid))
            {
                return;
            }
            Advertisement.Show(rewardedAdAndroid);
        }

        else
        {
            if (!Advertisement.IsReady(rewardedAdApple))
            {
                return;
            }
            Advertisement.Show(rewardedAdApple);
        }
    }
}
