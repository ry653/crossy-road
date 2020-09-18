using Helper;
using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsHelper : MonoBehaviour
{
    private string gameId;

    [Header("Game ID")]
    [SerializeField] private string googlePlayId;
    [SerializeField] private string appStoreId;

    private void Awake()
    {
#if UNITY_ANDROID
        gameId = googlePlayId;

#elif UNITY_IOS
                gameId = appStoreId;
#endif

        
    }
    private void Start()
    {
        Advertisement.Initialize(gameId);
    }

    public void showVideoAd()
    {
        if (UnityAdsVideoHelper.isReady())
        {
            UnityAdsVideoHelper.Show();
        }
    }

    public void ShowUnityAdsRewarded(Action<ShowResult> collback)
    {
        if (UnityAdsRewardedHelper.isReady())
        {
            UnityAdsRewardedHelper.Show(collback);
        }
    }

    public void DemoRewardedVideoAd()
    {
        ShowUnityAdsRewarded(result =>
        {
            switch (result)
            {
                case ShowResult.Failed:
                    Debug.Log("showResult => Failed");
                    break;
                case ShowResult.Skipped:
                    Debug.Log("showResult => Skipped");
                    break;
                case ShowResult.Finished:
                    Debug.Log("showResult => Finished");
                    break;
                default:
                    break;
            }
        });
    }


}
