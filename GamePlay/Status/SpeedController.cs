using System.Collections;
using UnityEngine;


    public class SpeedController
    {
        private float _currentSpeed;
        private float _maxSpeed;
        private float _speedIntencity;
        private float _accelerationIntencity;
        private float _accelerationTarget;

        private float _tempSpeed;

        private Coroutine _acceleration;
        public float Speed => _currentSpeed;

        public SpeedController(float accelerationIntencity,float accelerationTarget, float maxSpeed, float speedIntensivity)
        {
            _maxSpeed = maxSpeed;
            _speedIntencity = speedIntensivity;
            _accelerationIntencity = accelerationIntencity;
            _accelerationTarget = accelerationTarget;
        }

        public void ResetSpeed()
        {
            _currentSpeed = 0;
            _tempSpeed = 0;
        }

        public void Stop()
        {
            _tempSpeed = _currentSpeed;
            _currentSpeed = 0;
        }

        public void StartAcceleration()
        {
            _currentSpeed = _tempSpeed;
        }

        public void UpdateSpeed()
        {
            if (_currentSpeed < _maxSpeed)
                _currentSpeed += _speedIntencity;
        }
        


        private  IEnumerator Accelerate(float targetSpeed, float speedIntencity)
        {
            // while (_currentSpeed < targetSpeed)
            // {
                // yield return new WaitForSeconds(0.1f);
                // _currentSpeed += speedIntencity;
            // }

            // Coroutines.StopRoutine(_acceleration);
            yield return null;
        }
    }
