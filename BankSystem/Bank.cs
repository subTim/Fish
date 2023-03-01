using System;
using Unity.VisualScripting;
using UnityEngine;


public class Bank : MonoBehaviour
{
    public event Action<int> OnCoinsValueChagedInfo;
    public event Action OnCoinsValueChaged;
    public event Action OnPurchase;

    private int _coinsInBuffer;

    public void AddCoins(int amount)
    {
        _coinsInBuffer += amount;
        OnCoinsValueChagedInfo?.Invoke(amount);
        OnCoinsValueChaged?.Invoke();
    }

    public void PurchaseItem(ShopItem purchsingShopItem)
    {
        if (CanPurchase(purchsingShopItem.Price))
        {
            LoadCoins(-purchsingShopItem.Price);
            purchsingShopItem.Sell();
            OnPurchase?.Invoke();
            OnCoinsValueChaged?.Invoke();
        }
        else
        {
            throw new InvalidImplementationException();
        }
    }

    public bool CanPurchase(int sum) => GetCoinsValue() >= sum;

    public void LoadBufferCoins()
    {
        LoadCoins(_coinsInBuffer);
        _coinsInBuffer = 0;
    }

    private void LoadCoins(int amount)
    {
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + amount);
    }

    public int GetCoinsValue()
    {
        return PlayerPrefs.GetInt("coins");
    }
}
