using DG.Tweening;
using UnityEngine;



public class PosiitonUIAnimation : UiAnimationBase
{
    private RectTransform _rectTrasform;
    private Vector2 _offsetedPosition;
    private Vector2 _normalPosition;

    public PosiitonUIAnimation(GameObject obj, Vector2 offset)
    {
        MyGameObject = obj;
        _rectTrasform = obj.GetComponent<RectTransform>();

        var anchoredPosition = _rectTrasform.anchoredPosition;

        _normalPosition = anchoredPosition;
        _offsetedPosition = anchoredPosition + offset;
    }


    protected override void Animate()
    {
        AnimaePosition(_normalPosition);
    }

    protected override void AnimateRevers()
    {
        AnimaePosition(_offsetedPosition);
    }

    protected override void SetInActive()
    {
        _rectTrasform.anchoredPosition = _offsetedPosition;
    }

    private void AnimaePosition(Vector2 targetPosion)
    {
        DOTween.Sequence().SetDelay(DelayAnimation).SetLink(_rectTrasform.gameObject).SetEase(Ease.OutBack)
            .Append(_rectTrasform.DOAnchorPos(targetPosion, DurationAnimation));
    }
}
