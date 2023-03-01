using UnityEngine;


    public class DistanceController : IDayCycled, IGameStatsProvider
    {
        private DistanceTracker _tracker;
        private float _lastTimeSetDistance;
        
        public DistanceController(DistanceTracker tracker)
        {
            _tracker = tracker;
        }
        
        public int GetNowDone()
        {
            var digit = (int ) _tracker.GonePerGame;
            return digit;
        }
        
        public int GetMaximum()
        {
            return (int) PlayerPrefs.GetFloat("score");
        }

        public void TrySetRecord()
        {
            var score =  PlayerPrefs.GetFloat("score");
           
            if (_tracker.GonePerGame > score)
            {
                PlayerPrefs.SetFloat("score",_tracker.GonePerGame );
            }
        }


        public void AddTodayDone()
        {
            var offset =  PlayerPrefs.GetFloat("distanceToday") + _tracker.GonePerGame - _lastTimeSetDistance;
            
            _lastTimeSetDistance = _tracker.GonePerGame;
            
            PlayerPrefs.SetFloat("distanceToday", offset);
        }
        

        public void ResetTodays()
        {
            ResetPeriod();
            PlayerPrefs.SetFloat("distanceToday", 0f);
        }

        public void ResetPeriod()
        {
            _tracker.ResetGoneDistance();
            _lastTimeSetDistance = 0f;
        }


        public int GetTodayDone()
        {
            AddTodayDone();
            
            return (int)PlayerPrefs.GetFloat("distanceToday");
        }
        
    }
