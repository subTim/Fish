using System;


    public abstract class GameState
    {
        protected Game GameMaster;
        protected Type NextState;
        protected GlobalStateMachine StateMachine;
        protected UiActivityControll UiActivity;

        public GameState(Game gameMaster,UiActivityControll uiActivity, GlobalStateMachine machine)
        {
            GameMaster = gameMaster;
            UiActivity = uiActivity;
            StateMachine=  machine;
        }

        public abstract void OnEnter();
        public virtual void OnExit(){}
        public virtual void Update(){}

        public virtual void SetNext()
        {
            StateMachine.ChangeState(NextState);
        }
    }
