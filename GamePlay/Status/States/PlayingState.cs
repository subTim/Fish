

public class PlayingState : GameState
{
    public PlayingState(Game gameMaster, UiActivityControll uiActivity, GlobalStateMachine machine) : base(gameMaster,
        uiActivity, machine)
    {
        NextState = typeof(CollidedState);
    }

    public override void OnEnter()
    {
        UiActivity.PlayingState();
        GameMaster.Speed.StartAcceleration();
        GameMaster.PlayerMain.SetEnableToPressTrue();
        GameMaster.Generation.StartCheck();
    }

    public override void OnExit()
    {
        GameMaster.Generation.StopCheck();
    }

    public override void Update()
    {
        GameMaster.Stats.UpdateData();
        GameMaster.Speed.UpdateSpeed();
    }
}
