 using UnityEngine;

 public class LoaderAdsRewarder : LoaderAdsInterstetial
 {
     private AdsController _ads;

     public LoaderAdsRewarder(string adsLoadType, AdsController controller) : base(adsLoadType)
     {
         _ads = controller;
         Debug.Log(adsLoadType);
     }

     public override void OnUnityAdsAdLoaded(string placementId)
     {
         base.OnUnityAdsAdLoaded(placementId);
         Debug.Log("Loaded");
         _ads.OnOnLoadEvent();
     }
 }