using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    public void ShowRewardedAd()
    {
        Debug.Log("Showing rewarded ad");
       
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions
            {
                resultCallback = HandleShowResult
            };
            Advertisement.Show("rewardedVideo", options);
        }
        void HandleShowResult(ShowResult result)
        {
            switch (result)
            {
                case ShowResult.Finished:
                    //award 100 gems
                    break;
                case ShowResult.Skipped:
                    Debug.Log("Ad skipped no gems given");
                    break;
                case ShowResult.Failed:
                    Debug.Log("Ad failed no gems given");
                    break;
                default:
                    break;
            }
        }
    }
}
