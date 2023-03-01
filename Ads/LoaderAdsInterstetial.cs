
using UnityEngine;
using UnityEngine.Advertisements;


public class LoaderAdsInterstetial : IUnityAdsLoadListener
{
    protected string _adsType;
    private bool _isLoaded;
    public bool IsLoaded => _isLoaded;

    public LoaderAdsInterstetial(string adsLoadType)
    {
        _adsType = adsLoadType;
    }

    public virtual void LoadAd()
    {
        Advertisement.Load(_adsType, this);
    }

    public virtual void OnUnityAdsAdLoaded(string placementId)
    {
        _isLoaded = true;
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        _isLoaded = false;
    }
}