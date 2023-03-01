

public class StartState : GameState
{
    public StartState(Game gameMaster, UiActivityControll uiActivity, GlobalStateMachine machine) : base(gameMaster,
        uiActivity, machine)
    {
        NextState = typeof(PlayingState);
    }
    
    public override void OnEnter()
    {
        GameMaster.Time.CheackDataActuallity();
        GameMaster.Speed.ResetSpeed();
        UiActivity.StartState();
    }

    public override void OnExit()
    {
        GameMaster.PlayerMain.CameraMove();
    }
}
