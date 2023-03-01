using UnityEngine;
using UnityEngine.Advertisements;


   public class ShowerAds : IUnityAdsShowListener
    {
        private LoaderAdsInterstetial _loaderAdsInterstetial;
        protected string AdsType;
        public ShowerAds(string adsType, LoaderAdsInterstetial loaderRef)
        {
            AdsType = adsType;
            _loaderAdsInterstetial = loaderRef;
        }

        public virtual void ShowAd() 
        {
            Advertisement.Show(AdsType, this);
            _loaderAdsInterstetial.LoadAd();
        }
        
        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            Time.timeScale = 1;
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            Time.timeScale = 0;
        }
        

        public void OnUnityAdsShowClick(string placementId)
        {
        }
          public virtual void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            Time.timeScale = 1;
        }
    }
