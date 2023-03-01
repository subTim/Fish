using System;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    [SerializeField] private Ui ui;
    [SerializeField] private TasksController tasks;
    [SerializeField] private List<EnvirounmentGemerator> generators;
    [SerializeField] private Player player;
    [SerializeField] private Bank bank;
    [SerializeField] private AdsController ads;

    [SerializeField] private float generationDistance;
    [SerializeField] private float speedIntensity;
    [SerializeField] private float accelerationIntensity;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float accelerationMax;

    [SerializeField, Range(0f, 24f)] private float timeGap;

    public GameStats Stats => _gameStatsProvider;
    public Bank BankHSystem => bank;
    public SpeedController Speed => _speedController;
    public Player PlayerMain => player;
    public GenerationController Generation => _generationControll;

    public TimeController Time => _timeController;
    public Ui Ui => ui;
    public AdsController Ads => ads;

    private GenerationController _generationControll;
    private SpeedController _speedController;
    private GameStats _gameStatsProvider;
    private TimeController _timeController;
    private Rewarder _rewarder;

    private GlobalStateMachine _stateMachine;

    private void Awake()
    {
        SetGameSettings();
        ConstructTimeSystem();
        ConstructSpeed();
        _rewarder = new Rewarder(BankHSystem, this);
        ads.Init();
    }

    private void Start()
    {
        ConstructGameStats();
        ui.Init();
        ConstructGeneration();
        tasks.Init(_rewarder);
    }

    private void Update()
    {
        _stateMachine.UpdateData();
        _generationControll.Move(UnityEngine.Time.deltaTime);
    }

    private void OnDestroy()
    {
        _generationControll.OnDestroy();
    }

    public void RestartGame() => _stateMachine.Restart();

    public void StartState() => _stateMachine.ChangeState(typeof(StartState));
    public void PlayingState() => _stateMachine.ChangeState(typeof(PlayingState));
    public void CollidedState() => _stateMachine.ChangeState(typeof(CollidedState));
    public void PausedState() => _stateMachine.ChangeState(typeof(PausedState));
    public void EndState() => _stateMachine.ChangeState(typeof(EndState));

    private void SetGameSettings()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = Screen.currentResolution.refreshRate > 70 ? 0 : 1;
    }

    private void ConstructTimeSystem()
    {
        _timeController = new TimeController( timeGap);

        Ads.GetRewardables().ForEach(dependance => _timeController.Dependences.Add(dependance));
        _timeController.Dependences.Add(tasks);
    }
    
    private void ConstructSpeed()
    {
        _speedController = new SpeedController(accelerationIntensity, accelerationMax,
            maxSpeed, speedIntensity);
    }

    private void ConstructGameStats()
    {
        _stateMachine = new GlobalStateMachine(this, ui.ActivityControll);
        _gameStatsProvider = new GameStats(bank, player.PlayerInput, _speedController);
        _timeController.Dependences.Add(_gameStatsProvider);
    }
    
    private void ConstructGeneration()
    {
        _generationControll = new GenerationController(generators, _speedController, generationDistance);
        _generationControll.Generate();
    }
}    