public abstract class GameView : ProviderReciever<GameStats>
{
    protected bool CanUpdate;
    protected IGameStatsProvider Provider;


    protected virtual void OnEnable()
    {
        if (GotProvider)
            StartUpdate();

        RecievProvider += StartUpdate;
    }

    protected void OnDisable()
    {
        StopUpdate();
        RecievProvider -= StartUpdate;
    }

    public abstract void UpdateData();

    public override void GetProvider(GameStats statsProvider)
    {
        base.GetProvider(statsProvider);
        RecievProvider?.Invoke();
        GotProvider = true;
    }

    protected void StartUpdate() => CanUpdate = true;
    protected void StopUpdate() => CanUpdate = false;
}
