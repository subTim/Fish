
public class GameStats : ITimeDependenced
{
    private DistanceTracker _distanceTracker;
    private DistanceController _distanceController;

    private MoneyTracker _moneyTracker;
    private MoneyController _moneyController;

    private SwipesTracker _swipesTracker;
    private SwipesController _swipesController;

    public DistanceController GetDistanceController => _distanceController;
    public MoneyController GetMoneyController => _moneyController;
    public SwipesController GetSwipesController => _swipesController;

    public GameStats(Bank bank, InputBase input, SpeedController speedController)
    {
        _distanceTracker = new DistanceTracker(speedController);
        _distanceController = new DistanceController(_distanceTracker);

        _moneyTracker = new MoneyTracker(bank);
        _moneyController = new MoneyController(_moneyTracker);

        _swipesTracker = new SwipesTracker(input);
        _swipesController = new SwipesController(_swipesTracker);
    }

    public void ResetGamePeriodStats()
    {
        _moneyController.AddTodayDone();
        _moneyController.ResetPeriod();
        _distanceController.AddTodayDone();
        _distanceController.ResetPeriod();
    }

    public void UpdateData()
    {
        _distanceTracker.TrackDistance();
    }

    public void ResetData()
    {
        _moneyController.ResetTodays();
        _distanceController.ResetTodays();
    }
}
