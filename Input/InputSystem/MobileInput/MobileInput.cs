using System;
using Unity.VisualScripting;
using UnityEngine;

public class MobileInput : InputBase
{
    private float _treahold;
    private bool _canSwipe;

    public MobileInput(float treahold)
    {
        _treahold = treahold;
    }
    
    public override void Track()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (IsEnd(touch))
                _canSwipe = true;

            if (_canSwipe)
            {
                var swipe = touch.deltaPosition;
                if (IsSwipe(swipe))
                {
                    if (IsHorizontal(swipe))
                        HorizontalSwipe(swipe);
                    else
                        VerticalSwipe(swipe);

                    _canSwipe = false;
                }
            }
        }
    }
    
    private void HorizontalSwipe(Vector2 swipe)
    {
        if (swipe.x > 0)
            OnSwipeRight();
        else
            OnSwipeLeft();
    }

    private void VerticalSwipe(Vector2 swipe)
    {
        if (swipe.y > 0)
            OnSwipeUp();
        else
            OnSwipeDown();
    }

    private bool IsStart(Touch touch) => touch.phase == TouchPhase.Began;
    private bool IsEnd(Touch touch) => touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled;

    private bool IsHorizontal(Vector2 swipe) => Math.Abs(swipe.x) > Math.Abs(swipe.y);
    
    private bool IsSwipe(Vector2 swipe) => swipe.magnitude > _treahold;
}