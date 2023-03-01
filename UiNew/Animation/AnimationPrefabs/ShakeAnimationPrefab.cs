using System;
using UnityEngine;


public class ShakeAnimationPrefab : UIAniimationBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private int frequensy;
    [SerializeField] private float strangth;

    private void OnDisable()
    {
        AnimationTree.SetAllInActive();
    }

    protected override void Init()
    {
        AnimationTree = new ShakeAnimation(rectTransform, strangth, frequensy);
        AnimationTree.SetDurationAssets(duration, delay);
    }
}
