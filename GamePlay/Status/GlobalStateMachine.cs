using System;
using System.Collections.Generic;


public class GlobalStateMachine
{
    public GameState State => _currentState;

    private GameState _currentState;
    private Dictionary<Type, GameState> _instansec = new(5);

    private StartState _start;
    private PlayingState _playing;
    private PausedState _paused;
    private CollidedState _collided;
    private EndState _endState;

    private Game _game;
    private UiActivityControll _activityControll;

    public GlobalStateMachine(Game game, UiActivityControll activityControll)
    {
        _game = game;
        _activityControll = activityControll;

        CreateStates();

        CreateComparer();

        _currentState = _start;
        _currentState.OnEnter();
    }

    private void CreateComparer()
    {
        _instansec[typeof(StartState)] = _start;
        _instansec[typeof(PlayingState)] = _playing;
        _instansec[typeof(PausedState)] = _paused;
        _instansec[typeof(CollidedState)] = _collided;
        _instansec[typeof(EndState)] = _endState;
    }

    private void CreateStates()
    {
        _start = new StartState(_game, _activityControll, this);
        _playing = new PlayingState(_game, _activityControll, this);
        _collided = new CollidedState(_game, _activityControll, this);
        _paused = new PausedState(_game, _activityControll, this);
        _endState = new EndState(_game, _activityControll, this);
    }

    public void Restart()
    {
        _game.Time.CheackDataActuallity();
        _game.Speed.ResetSpeed();
        _game.PlayerMain.CameraMove();
        ChangeState(typeof(PlayingState));
    }
    
    public void ChangeState(Type stateType)
    {
        _currentState.OnExit();
        _currentState = _instansec[stateType];
        _currentState.OnEnter();
    }

    public void UpdateData()
    {
        _currentState.Update();
    }
}
