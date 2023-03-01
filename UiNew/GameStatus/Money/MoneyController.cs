using UnityEngine;

    public class MoneyController :  IDayCycled, IGameStatsProvider
    {
        private MoneyTracker _tracker;
        private int _lastTimeCoinsChecked;

        public MoneyController(MoneyTracker tracker)
        {
            _tracker = tracker;
        }

        public int GetTodayDone()
        {
            AddTodayDone();
            
            return (int)PlayerPrefs.GetFloat("moneyToday");
        }

        public void AddTodayDone()
        {
            var offset = PlayerPrefs.GetFloat("moneyToday") + _tracker.GetPerGameCoins - _lastTimeCoinsChecked;
            _lastTimeCoinsChecked = _tracker.GetPerGameCoins;
            
            
            PlayerPrefs.SetFloat("moneyToday", offset);
            _lastTimeCoinsChecked = _tracker.GetPerGameCoins;
        }

        public int GetNowDone()
        {
            return _tracker.GetPerGameCoins;
        }

        public int GetMaximum()
        {
            return _tracker.GetAllCoins();
        }
        public void ResetTodays()
        {
            ResetPeriod();
            PlayerPrefs.SetFloat("moneyToday", 0f);
        }

        public void ResetPeriod()
        {
            _tracker.ResetPutPerGameCoins();
            _lastTimeCoinsChecked = 0;
        }
    }
