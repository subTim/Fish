

    using System;
    using UnityEngine;

    public class CollidedState : GameState
    {
        public CollidedState(Game gameMaster, UiActivityControll uiActivity, GlobalStateMachine machine) : base(gameMaster, uiActivity, machine)
        {
            NextState = typeof(EndState);
        }

        public override void OnEnter()
        {
            if (GameMaster.Ads.CanShow)
            {
                UiActivity.CollidedState();
            }
            else
            {
                StateMachine.ChangeState(typeof(EndState));
            }
            
            GameMaster.Speed.Stop();
        }
    }
