
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AdsRewardType : UiActivity, IRewardable
{
    [SerializeField] protected Button MyButtom;
    [SerializeField] private Rewards type;

    protected AdsController Ads;

    protected void Awake()
    {
        MyButtom.onClick.AddListener(Show);
    }

    protected void Show()
    {
        Ads.ShowAndReward(this); 
    }

    public void SetData(AdsController ads)
    {
        Ads = ads;
        Ads.OnLoadEvent += Enable;
    }
    
    public override void Enable()
    {
        if (Ads.CanShow)
        {
            SetInteractable();
            base.Enable();
        }
        else
        {
            SetInInteractable();
        }
    }
    
    public UnityAction OnComplite { get; set; }

    public Rewards GetRewardType() => type;
    
    public virtual void SetInInteractable() => MyButtom.interactable = false;
    public virtual void SetInteractable() => MyButtom.interactable = true;
}  
