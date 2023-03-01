public class PausedState : GameState
{
    public PausedState(Game gameMaster, UiActivityControll uiActivity, GlobalStateMachine machine) : base(gameMaster, uiActivity, machine)
    {
    }

    public override void OnEnter()
    {
        GameMaster.Generation.StopCheck();
        GameMaster.Speed.Stop();
        GameMaster.PlayerMain.SetEnableToPressFalse();
        GameMaster.Ui.ActivityControll.PausedState();
    }
}