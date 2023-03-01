using UnityEngine.Advertisements;

public class ShowerRewarderAds : ShowerAds
{
    private IRewardable _currentShowCell;
    public void Show(IRewardable cell)
    {
        _currentShowCell = cell;
        base.ShowAd();
    }

    public ShowerRewarderAds(string whatAdsType, LoaderAdsInterstetial loaderRef) : base(whatAdsType, loaderRef)
    {
    }

    public override void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        _currentShowCell.OnComplite();
        base.OnUnityAdsShowComplete(placementId, showCompletionState);
    }
}
