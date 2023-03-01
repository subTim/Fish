using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UiActivityAnimated : UiActivity
{
    [SerializeField] protected List<UIAniimationBehaviour> myAnimations;

    private bool _isAnimating;
    
    private void Start()
    {
        myAnimations.ForEach(anim =>  anim.SetInActive());
    }

    public override void GetProvider(UiActivityControll provider)
    {
        base.GetProvider(provider);
        myAnimations.ForEach(anim => anim.InitAnimation());
    }

    public override void Enable()
    {
        base.Enable();
        myAnimations.ForEach(anim => anim.Animate());
    }


    public override async void Disable()
    {
        myAnimations.ForEach(anim => anim.AnimateReverse());
        
        await  Task.Delay(myAnimations[0].Duration);;
        base.Disable();
    }
}