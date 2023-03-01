using UnityEngine;


    public class SwipesController : IDayCycled
    {
        private SwipesTracker _tracker;

        private int _lastTimeLeft;
        private int _lastTimeRight;
        private int _lastTimeUp;
        private int _lastTimeDown;

        public int GetLeft => _tracker.GetLeft;
        public int GetRight => _tracker.GetRight;
        public int GetUp => _tracker.GetUp;
        public int GetDown => _tracker.GetDown;
        
        
        public SwipesController(SwipesTracker tracker)
        {
            _tracker = tracker;
        }
        
        public int GetLeftToday()
        {

            AddLeftOffset();
            return PlayerPrefs.GetInt("swipedLeftToday");
        }

        public int GetRightToday()
        {
            AddRightOffset();
            return PlayerPrefs.GetInt("swipedRightToday");
        }
        
        public int GetUpToday()
        {
            AddUpOffSet();
            return PlayerPrefs.GetInt("swipedUpToday");
        }

        public int GetDownToday()
        {
            AddDownOffset();
            return PlayerPrefs.GetInt("swipedDownToday");
        }
        
        private void AddLeftOffset()
        {
            var offsetLeft =  PlayerPrefs.GetInt("swipedLeftToday") + _tracker.GetLeft - _lastTimeLeft ;
            PlayerPrefs.SetInt("swipedLeftToday", offsetLeft);
            _lastTimeLeft = _tracker.GetLeft;
        }
        
        private void AddRightOffset()
        {
            var offsetRight = PlayerPrefs.GetInt("swipedRightToday") + _tracker.GetRight - _lastTimeRight ;
            PlayerPrefs.SetInt("swipedRightToday", offsetRight);
            _lastTimeRight = _tracker.GetRight;
        }
        
        private void AddUpOffSet()
        {
            var offsetUp = PlayerPrefs.GetInt("swipedUpToday") + _tracker.GetUp -_lastTimeUp ;
            PlayerPrefs.SetInt("swipedUpToday", offsetUp);
            _lastTimeUp = _tracker.GetUp;
        }
        
        private void AddDownOffset()
        {
            var offsetDown = PlayerPrefs.GetInt("swipedDownToday") + _tracker.GetDown -_lastTimeDown ;
            PlayerPrefs.SetInt("swipedDownToday", offsetDown);
            _lastTimeDown = _tracker.GetDown;
        }

        public void AddTodayDone()
        {
            AddLeftOffset();
            AddRightOffset();
            AddUpOffSet();
            AddDownOffset();
        }
        

        public void ResetTodays()
        {
            ResetPeriod();
            
            PlayerPrefs.SetInt("swipedLeftToday", 0);
            PlayerPrefs.SetInt("swipedRightToday", 0);
            PlayerPrefs.SetInt("swipedUpToday", 0);
            PlayerPrefs.SetInt("swipedDownToday", 0);
        }

        public void ResetPeriod()
        {
            _tracker.ResetAll();

            _lastTimeDown = 0;
            _lastTimeLeft = 0;
            _lastTimeRight = 0;
            _lastTimeUp = 0;
        }
    }
