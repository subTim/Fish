using DG.Tweening;
using UnityEngine;


public class ShakeAnimation : UiAnimationBase
{
    private RectTransform _rectTransform;
    private float _strength;
    private int _frequensy;
    private Vector2 _startPos;
    private Sequence _tween;
    public ShakeAnimation(RectTransform rectTransform, float strength, int frequensy)
    {
        _startPos = rectTransform.anchoredPosition;
        _rectTransform = rectTransform;
        _strength = strength;
        _frequensy = frequensy;
    }

    protected override void Animate()
    {
        DefaultAnimation();
    }

    protected override void AnimateRevers()
    {
        SetInActive();
    }

    private void DefaultAnimation()
    {
        _tween = DOTween.Sequence().SetDelay(DelayAnimation).SetLink(MyGameObject).SetEase(Ease.Linear)
            .Append(_rectTransform.DOShakeAnchorPos(DurationAnimation, _strength, _frequensy)).SetLoops(-1);
    }

    protected override void SetInActive()
    {
        _tween.Kill();
        _rectTransform.anchoredPosition = _startPos;
    }
}
