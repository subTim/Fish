using System;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private CamFollower cameraFollower;
    [SerializeField] private Positions poses;

    [SerializeField, Range(0f,50f)] private float threahold;
    [SerializeField, Range(0f,1f)] private float speedMultiplyer; 
    
    private InputBase _input;
    private bool _isEnableToMove;
    private PlayerMovment _movment;

    public InputBase PlayerInput => _input;

    private void Awake()
    {
        poses.Create();
        
        _input = new MobileInput(threahold);
        
        _movment = new PlayerMovment(poses, this, _input, speedMultiplyer);
        _movment.SetDefaultPos();
         
        SetEnableToPressFalse();
    }

    public void SetEnableToPressFalse() => _isEnableToMove = false;
    public void SetEnableToPressTrue() => _isEnableToMove = true;
    
    public void ResetAll()
    {
        cameraFollower.SetDefaultPos();
        SetEnableToPressFalse();
        _movment.SetDefaultPos();
    }

    public void CameraMove()
    {
        cameraFollower.DoCameraStartMove();
    }

    private void Update()
    {
        if (_isEnableToMove)
        {
            _input.Track();
        }
    }

    private void FixedUpdate()
    {
        if (_isEnableToMove)
        {
            _movment.Move();
        }
    }
}