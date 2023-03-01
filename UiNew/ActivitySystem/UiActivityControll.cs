using System;
using System.Collections.Generic;



public class UiActivityControll
{
    public event Action ResetOnEnd;
    private Ui _ui;

    public string GetTimeSpan() => _ui.GetTimeGapTillReset();

    private List<UiActivity> _uiCells = new ();

    private void SendEventInvocation(GameStates type)
    {
        foreach (var uicell in _uiCells)
            uicell.GetEvent(type);
    }

    public UiActivityControll(List<UiActivity> uiCells, Ui ui)
    {
        _ui = ui;

        foreach (var activity in uiCells)
        {
            activity.GetProvider(this);
            _uiCells.Add(activity);
        }
    }

    public void Reset() => ResetOnEnd?.Invoke();
    public void StartState() => SendEventInvocation(GameStates.Start);
    public void PlayingState() => SendEventInvocation(GameStates.Playing);
    public void CollidedState() => SendEventInvocation(GameStates.Collided);
    public void FinishState() => SendEventInvocation(GameStates.End);
    public void PausedState() => SendEventInvocation(GameStates.Paused);
}
