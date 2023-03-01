using System;
using DG.Tweening;
using UnityEngine.UI;


    public class SliderAnimation
    {
        public void Animate(Slider slider, float target , float duration = 1f)
        {
            var targetValue = Math.Clamp(target, 0, 1);
            DOTween.Sequence().SetEase(Ease.InOutExpo).Append(slider.DOValue(targetValue, duration));
        }
    }
