
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Advertisements;
using Random = UnityEngine.Random;


public class AdsController : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string androidGameId;
    [SerializeField] string iOSGameId;
    [SerializeField] bool testMode = true;
    [SerializeField, Range(0, 100)] private int chanceShowAd;
    [SerializeField] private List<AdsRewardType> rewardables;
    
    private ShowerRewarderAds _showerRewarder;
    private LoaderAdsInterstetial _loaderInterstatial;
    private LoaderAdsRewarder _loaderReward;
    
    private ShowerAds _showerInterstential;

    private string _abIDInterstential;
    private string _abIDRewarde;

    private const string AndroidAppInterstential = "Interstitial_Android";
    private const string AndroidAppReward = "Rewarded_Android";

    private string _gameId;
    
    private bool _isLoaded;
    
    public bool CanShow => _loaderReward.IsLoaded;
    public event Action OnLoadEvent;

    public List<ITimeDependenced> GetRewardables()
    {
        List<ITimeDependenced> go = new List<ITimeDependenced>(); 
        foreach (var rewardable in rewardables)
        {
            if (rewardable is ITimeDependenced)
                go.Add((ITimeDependenced) rewardable);        
        }

        return go;
    }
    
    public void OnOnLoadEvent()
    {
        OnLoadEvent?.Invoke();
    }

    public void Init()
    {
        InitializeAds();

        _loaderInterstatial = new LoaderAdsInterstetial(AndroidAppInterstential);
        _showerInterstential = new ShowerAds(AndroidAppInterstential, _loaderInterstatial);

        _loaderReward = new LoaderAdsRewarder(AndroidAppReward,this);
        _showerRewarder = new ShowerRewarderAds(AndroidAppReward, _loaderReward);
        
        _loaderInterstatial.LoadAd();
        _loaderReward.LoadAd();
        
        foreach (var rewardable in rewardables)
        {
            rewardable.SetData(this);
        }
    }
    
    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.Android ||
                   Application.platform == RuntimePlatform.WindowsEditor)
            ? androidGameId
            : iOSGameId;
        Advertisement.Initialize(_gameId, testMode, this);
    }
    
    public void ShowAndReward(IRewardable rewardable)
    {
        _showerRewarder.Show(rewardable);
    }
    
    public void ShowInterstential()
    {
        if (chanceShowAd >= Random.Range(0, 100))
        {
            _showerInterstential.ShowAd();
        }
    }

    public void OnInitializationComplete()
    {
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
    }
}
