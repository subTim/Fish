
using UnityEngine;

public class EndState : GameState
{
    public EndState(Game gameMaster, UiActivityControll uiActivity, GlobalStateMachine machine) : base(gameMaster,
        uiActivity, machine)
    {
        NextState = typeof(StartState);
    }

    public override void OnEnter()
    {
        UiActivity.FinishState();
    }

    public override void OnExit()
    {
        GameMaster.Ui.ActivityControll.Reset();
        GameMaster.Generation.Generate();
        GameMaster.PlayerMain.ResetAll();
        GameMaster.Stats.ResetGamePeriodStats();
        GameMaster.Ads.ShowInterstential();
        GameMaster.BankHSystem.LoadBufferCoins();
        GameMaster.Stats.ResetGamePeriodStats();
        GameMaster.BankHSystem.LoadBufferCoins();
        GameMaster.Stats.GetDistanceController.TrySetRecord();
    }
}
