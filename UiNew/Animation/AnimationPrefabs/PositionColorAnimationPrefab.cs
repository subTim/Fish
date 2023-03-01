using UnityEngine;


public class PositionColorAnimationPrefab : UIAniimationBehaviour
{
    [SerializeField] private Vector2 offset;
    [SerializeField] protected CanvasGroup group;

    protected override void Init()
    {
        AnimationTree = new PosiitonUIAnimation(gameObject, offset);
        AnimationTree.SetDurationAssets(duration, delay);
        AnimationTree.SetNext(new ColorUIAnimation(group));
    }
}
