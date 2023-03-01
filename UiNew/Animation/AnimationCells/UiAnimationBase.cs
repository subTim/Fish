using System;
using UnityEngine;

public enum AnimationType
{
    Common,
    Reverse
}

public abstract class UiAnimationBase
{
    protected UiAnimationBase NextOne;
    protected float DurationAnimation;
    protected float DelayAnimation;
    protected GameObject MyGameObject;
    private bool _isAnimating;

    public bool IsAnimating => _isAnimating;

    public void SetDurationAssets(float duration, float delay)
    {
        DurationAnimation = duration;
        DelayAnimation = delay;
    }

    public void SetNext(UiAnimationBase next)
    {
        NextOne = next;
        InitNext();
    }

    public int GetAllDuration()
    {
        var duration = (int)(DelayAnimation + DurationAnimation);
        return duration;
    }

    protected void InitNext()
    {
        if (NextOne != null)
        {
            NextOne.MyGameObject = MyGameObject;
            NextOne.DelayAnimation = DelayAnimation;
            NextOne.DurationAnimation = DurationAnimation;
        }
    }

    private void AnimateAccordingType(AnimationType animation)
    {
        switch (animation)
        {
            case AnimationType.Common:
            {
                Animate();
                break;
            }
            case AnimationType.Reverse:
            {
                AnimateRevers();
                break;
            }
            default:
                throw new Exception("Cant execute");
        }
    }

    public void ExecuteAnimations(AnimationType animationType)
    {
        AnimateAccordingType(animationType);
        if (NextOne != null)
        {
            NextOne.ExecuteAnimations(animationType);
        }
    }
    

    public void SetAllInActive()
    {
        SetInActive();

        if (NextOne != null)
        {
            NextOne.SetInActive();
        }
    }

    protected abstract void Animate();
    protected abstract void AnimateRevers();
    protected abstract void SetInActive();
}
