using System;
using System.Threading.Tasks;
using UnityEngine;


public abstract class UIAniimationBehaviour : MonoBehaviour
{
    [SerializeField] protected float delay;
    [SerializeField] protected float duration;
    [SerializeField] protected bool isReversed;

    private bool _isAnimatin;
    public bool IsAnimating => _isAnimatin;

    protected UiAnimationBase AnimationTree;

    public int Duration => AnimationTree.GetAllDuration() * 1000;
    

    public void InitAnimation()
    {
        Init();
        if (isReversed)
        {
            SetInActive();
        }
    }

    protected abstract void Init();

    public async void Animate()
    {
        _isAnimatin = true;
        if(AnimationTree == null)
            Debug.Log(gameObject);

        AnimationTree.ExecuteAnimations(AnimationType.Common);
            await Task.Delay(Duration);
            _isAnimatin = false;

    }

    public async void AnimateReverse()
    {
        _isAnimatin = true;
        AnimationTree.ExecuteAnimations(AnimationType.Reverse);
        await Task.Delay(Duration);
        _isAnimatin = false;
    }

    public void SetInActive()
    {
        AnimationTree.SetAllInActive();
    }

}