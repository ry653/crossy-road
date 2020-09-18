using UnityEngine.Advertisements;

namespace Helper
{
    public static class UnityAdsVideoHelper
    {
        public static bool isReady() => Advertisement.IsReady("video");

        public static void Show()
        {
            Advertisement.Show("video");
        }
    }
}