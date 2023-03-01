using System;


public abstract class InputBase 
{
    public event Action SwipeLeft;
    public event Action SwipeRight;
    public event Action SwipeUp;
    public event Action SwipeDown;
    
    protected void OnSwipeLeft()
    {
        SwipeLeft?.Invoke();
    }

    protected void OnSwipeRight()
    {
        SwipeRight?.Invoke();
    }

    protected void OnSwipeUp()
    {
        SwipeUp?.Invoke();
    }

    protected void OnSwipeDown()
    {
        SwipeDown?.Invoke();
    }

    public abstract void Track();
}
