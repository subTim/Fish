
    public class MoneyTracker
    {
        private Bank _bank;
        private int _getPerGame;
        public int GetPerGameCoins => _getPerGame;
        
        public MoneyTracker(Bank bank)
        {
            _bank = bank;
            _bank.OnCoinsValueChagedInfo += count =>
            {
                _getPerGame += count;
            };
        }

        public int GetAllCoins()
        {
           return _bank.GetCoinsValue();
        }

        public void ResetPutPerGameCoins()
        {
            _getPerGame = 0;
        }
        
    }
