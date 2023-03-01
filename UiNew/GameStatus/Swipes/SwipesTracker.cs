public class SwipesTracker
{
    private InputBase _inputMaster;

    private int _leftSwipes;
    private int _rightSwipes;
    private int _upSwipes;
    private int _downSwipes;
    public int GetLeft => _leftSwipes;
    public int GetRight => _rightSwipes;
    public int GetUp => _upSwipes;
    public int GetDown => _downSwipes;


    public SwipesTracker(InputBase inputMaster)
    {
        _inputMaster = inputMaster;

        Subscribe();
    }

    private void Subscribe()
    {
        _inputMaster.SwipeLeft += AddLeftSwipes;
        _inputMaster.SwipeRight += AddRightSwipes;
        _inputMaster.SwipeUp += AddUpSwipes;
        _inputMaster.SwipeDown += AddDownSwipes;
    }

    public void ResetAll()
    {
        _leftSwipes = 0;
        _rightSwipes = 0;
        _upSwipes = 0;
        _downSwipes = 0;
    }

    private void AddLeftSwipes()
    {
        _leftSwipes++;
    }

    private void AddRightSwipes()
    {
        _rightSwipes++;
    }

    private void AddUpSwipes()
    {
        _upSwipes++;
    }

    private void AddDownSwipes()
    {
        _downSwipes++;
    }
}
