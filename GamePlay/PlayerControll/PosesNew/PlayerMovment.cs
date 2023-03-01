using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovment
{
    private Positions _positions;
    private Player _player;

    private float _speedMultiplyer;
    private Vector3 _targetPosition;
    private Queue<Vector3> _actions = new ();
    
    private const float ROUND_UP = 0.1f;
    private const int DEFAULT_POS_INDEX = 4;

    private Vector3 PlayerPosition
    {
        get { return _player.transform.position; }
        set { _player.transform.position = value; }
    }
    
    public PlayerMovment(Positions posesData, Player player, InputBase input, float speedMultiplyer)
    {
        _positions = posesData;
        _player = player;
        _speedMultiplyer = speedMultiplyer ;

        input.SwipeDown += Down;
        input.SwipeLeft += Left;
        input.SwipeRight += Right;
        input.SwipeUp += Up;
    }

    public void Move()
    {
        PlayerPosition = Vector3.Lerp( PlayerPosition, _targetPosition, Time.fixedTime * _speedMultiplyer);
            
        if (IsMoving() == false && _actions.Count > 0)
            SetNextAction();
    }

    private bool IsMoving() => !(ROUND_UP > Mathf.Abs(PlayerPosition.magnitude - _targetPosition.magnitude));

    private void AddMovementToQueue(int index)
    {
        var move = GetPostionByIndex(
            GetIndexByVector(_targetPosition) + index);
        
         _actions.Enqueue(move);
    }

    public void SetDefaultPos()
    {
        PlayerPosition = _targetPosition = _positions[DEFAULT_POS_INDEX];
    }

    private void SetNextAction()
    {
        PlayerPosition = _targetPosition;
        _targetPosition = _actions.Dequeue();
    }

    public void Left()
    {
        if (_positions.IsLeft(_targetPosition) == false)
            AddMovementToQueue(_positions.LeftIntOffest);
    }

    public void Right()
    {
        if (_positions.IsRight(_targetPosition) == false)
            AddMovementToQueue(_positions.RightIntOffset);
    }

    public void Up()
    {
        if (_positions.IsUp(_targetPosition) == false)
            AddMovementToQueue(_positions.UpIntOffset);
    }

    public void Down()
    {
        if (_positions.IsDown(_targetPosition) == false)
            AddMovementToQueue(_positions.DownIntOffest);
    }

    private Vector3 GetPostionByIndex(int index) => _positions[index];

    private int GetIndexByVector(Vector3 pos) => _positions[pos];
    
}

