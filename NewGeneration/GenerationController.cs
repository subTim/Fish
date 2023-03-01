using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;


public class GenerationController 
{
    public const float REMOVMENT_CORDX = -20f;


    private List<EnvirounmentGemerator> _generators;
    private SpeedController _speedController;
    private float _maxDistance;

    private CancellationTokenSource _tokenSource;
    private CancellationToken _currentCancelation;


    public GenerationController(List<EnvirounmentGemerator> generators, SpeedController speedController,
        float generationDistance)
    {
        _generators = generators;
        _speedController = speedController;
        _maxDistance = generationDistance;
    }

    public void Move(float deltaTime)
    {
        foreach (var generator in _generators)
        {
            generator.Parent.transform.position -= new Vector3((deltaTime * _speedController.Speed), 0f, 0f);
        }
    }

    public void Generate()
    {
        foreach (var generator in _generators)
        {
            generator.RemoveAll();
            generator.CreateObjecs(_maxDistance);
        }

    }

    private void TranslateItems() => _generators.ForEach(generator =>
        generator.Translate(REMOVMENT_CORDX));

    public void StartCheck()
    {
        _tokenSource = new CancellationTokenSource();
        _currentCancelation = _tokenSource.Token;
        Check();
    }

    public void StopCheck()
    {
        if (_tokenSource != null)
            _tokenSource.Cancel();
    }

    public void OnDestroy()
    {
        StopCheck();
    }

    private async void Check()
    {
        while (true)
        {
            if (_currentCancelation.IsCancellationRequested)
                return;

            TranslateItems();

            var timeToWait = Task.Delay(3000);
            await timeToWait;
        }
    }
}