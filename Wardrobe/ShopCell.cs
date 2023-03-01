using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;


public class ShopCell : MonoBehaviour
{
    [SerializeField] private Image cellImage;
    [SerializeField] private Button cellController;
    
    private ShopItem _shopItem;
    private Shop _shop;

    public bool IsPurchased => _shopItem.Sold;

    private void Awake()
    {
        cellController.onClick.AddListener(OnClick);
    }
    
    public void SetInfo(ShopItem shopItem, Shop shop)
    {
        _shopItem = shopItem;
        _shop = shop;
    }

    public void Render()
    {
        cellImage.sprite = _shopItem.Image;
    }

    public void OnClick()
    {
        _shop.HandleSelection(_shopItem);
    }
}
