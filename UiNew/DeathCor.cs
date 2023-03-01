using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class DeathCor : UiActivityAnimated
{
    [SerializeField] private float animationDuration;
    [SerializeField] private int countOfResurection;
    [SerializeField] private Image circle;
    [SerializeField] private Game game;

    private int _countOfResurectionsLocal;

    public override void GetProvider(UiActivityControll provider)
    {
        base.GetProvider(provider);
        Provider.ResetOnEnd += ResetData;
        ResetData();
    }

    private void ResetData()
    {
        _countOfResurectionsLocal = countOfResurection;
    }

    public override void Enable()
    {
        base.Enable();
        circle.fillAmount = 1f;
        if (_countOfResurectionsLocal != 0)
        {
            StartCoroutine(Wait());
            _countOfResurectionsLocal--;
        }
    }

    public override void Disable()
    {
        base.Disable();
        StopAllCoroutines();
    }

    private IEnumerator Wait()
    {
        while (circle.fillAmount > 0)
        {
            circle.fillAmount -= Time.deltaTime * animationDuration;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}