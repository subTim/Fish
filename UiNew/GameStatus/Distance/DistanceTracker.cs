using UnityEngine;


    public class DistanceTracker
    {
        public float GonePerGame => (int)_gonePerGame;
        private float _gonePerGame;

        private SpeedController _speedController;

        public DistanceTracker(SpeedController speedController)
        {
            _speedController = speedController;
        }

        public void TrackDistance()
        {
            _gonePerGame +=  _speedController.Speed * Time.deltaTime;
        }

        public void ResetGoneDistance()
        {
            _gonePerGame = 0f;
        }


    }
