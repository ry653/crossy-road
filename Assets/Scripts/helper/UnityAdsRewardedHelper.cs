using System;
using UnityEngine.Advertisements;

namespace Helper
{
    public static class UnityAdsRewardedHelper
    {
        public static bool isReady() => Advertisement.IsReady("rewardedVideo");

        public static void Show(Action<ShowResult> collback)
        {
            ShowOptions options = new ShowOptions
            {
                resultCallback = collback
            };
            Advertisement.Show("rewardedVideo", options);
        }
    }
}


