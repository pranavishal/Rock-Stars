using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAdsMainMenu : MonoBehaviour
{
    string googlePlayID = "4048966";
    string appleStoreID = "4048967";

    

    public string bannerAndroid = "Banner_Android";
    public string bannerApple = "Banner_iOS";

    public bool testMode = true;
    public bool isTargetPlayStore;
    // Start is called before the first frame update
    void Start()
    {
        InitializeAdvertisements();
        StartCoroutine(ShowBannerWhenReady());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeAdvertisements()
    {
        if (isTargetPlayStore)
        {
            Advertisement.Initialize(googlePlayID, testMode);
            return;
        }

        Advertisement.Initialize(appleStoreID, testMode);

    }

    public IEnumerator ShowBannerWhenReady()
    {
        if (isTargetPlayStore)
        {
            while (!Advertisement.IsReady(bannerAndroid))
            {
                yield return new WaitForSeconds(0.5f);
                
            }
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(bannerAndroid);
        }

        else
        {
            while (!Advertisement.IsReady(bannerApple))
            {
                yield return new WaitForSeconds(0.5f);
            }
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(bannerAndroid);
            
        }
    }

    public void DestroyAds()
    {
        Advertisement.Banner.Hide(false);
    }
}
