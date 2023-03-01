
using System.Collections.Generic;
using UnityEngine;


public enum GameStates
{
    Start,
    Playing,
    Collided,
    Paused,
    End
}

public class UiActivity : ProviderReciever<UiActivityControll>
{
    [SerializeField] protected GameStates myEvent;
    protected UiActivityControll Provider;

    public override void GetProvider(UiActivityControll provider)
    {
        Provider = provider;
        GotProvider = true;
    }

    public void GetEvent(GameStates gameStates)
    {
        if (myEvent == gameStates)
            Enable();
        else if (gameObject.activeSelf)
            Disable();
    }

    public virtual void Enable()
    {
        gameObject.SetActive(true);
    }

    public virtual void Disable()
    {
        gameObject.SetActive(false);
    }
}