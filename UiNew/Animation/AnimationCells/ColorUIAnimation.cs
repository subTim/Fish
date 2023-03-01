using DG.Tweening;
using UnityEngine;


public class ColorUIAnimation : UiAnimationBase
{
    private CanvasGroup _group;
    private float _visible;
    private float _inVisible = 0f;


    public ColorUIAnimation(CanvasGroup renderers)
    {
        _group = renderers;
        _visible = renderers.alpha;
    }


    private void ColorAnimate(float targetAlfa)
    {
        DOTween.Sequence().SetDelay(DelayAnimation).SetEase(Ease.OutExpo)
            .Append(_group.DOFade(targetAlfa, DurationAnimation));
    }

    protected override void Animate()
    {
        ColorAnimate(_visible);
    }

    protected override void AnimateRevers()
    {
        ColorAnimate(_inVisible);
    }

    protected override void SetInActive()
    {
        _group.alpha = _inVisible;
    }
}
