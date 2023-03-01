using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gift : AdsRewardType,ITimeDependenced, IRewardableValue
{
    [SerializeField] private List<int> rewardValues;
    [SerializeField] private TextMeshProUGUI giftText;
    [SerializeField] private ShakeAnimationPrefab myAnimation;

    private bool _isEnable;

    private const string GIFT_ACTIVITY = "giftActivity";
    private const string GIFT_REWARD_KEY = "gitRewardKey";

    public int GetValue() => PlayerPrefs.GetInt(GIFT_REWARD_KEY);

    new private void Awake()
    {
        OnComplite += () => SetRewarded();
    }

    public void ResetData()
    {
        var coins = rewardValues[Random.Range(0, rewardValues.Count)];
        PlayerPrefs.SetInt(GIFT_REWARD_KEY, coins);
        PlayerPrefs.SetInt(GIFT_ACTIVITY, 0);
        SetInteractable();
    }

    private void Update()
    {
        if (GotProvider && _isEnable == false)
        {
            giftText.text = Provider.GetTimeSpan();
        }
    }

    public override void GetProvider(UiActivityControll provider)
    {
        base.GetProvider(provider);
        myAnimation.InitAnimation();
    }

    public void SetRewarded()
    {
        PlayerPrefs.SetInt(GIFT_ACTIVITY, 1);
        SetInInteractable();
    }

    public override void SetInInteractable()
    {
        base.SetInInteractable();
        myAnimation.SetInActive();
        _isEnable = false;
    }

    public override void SetInteractable()
    {
        base.SetInteractable();
        giftText.text = GetValue().ToString();
        myAnimation.Animate();
        _isEnable = true;
    }
    

    public override void Enable()
    {
        if (Ads.CanShow)
        {
            if (PlayerPrefs.GetInt(GIFT_ACTIVITY) == 0)
            {
                SetInteractable();
            }
            else
            {
                SetInInteractable();
            }
        }
        else
        {
            gameObject.SetActive(false);
        }       
    }
}