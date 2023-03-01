using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<ShopItem> items;
    
    [SerializeField] private ShopCell cellPrefab;
    [SerializeField] private Transform containerTransform;
    [SerializeField] private SkinsControll wardrobe;
    [SerializeField] private Bank bank;

    [SerializeField] private DefaultAnimationController confirmationMenu;
    [SerializeField] private SelectButton select;

    private List<ShopCell> _activeCells = new ();
    private ShopItem _selectedShopItem;

    public List<ShopItem> ItemCells => items;


    private void Awake()
    {
        CreateCells();
        RenderCells();
    }
    

    private void OnEnable()
    {
        select.gameObject.SetActive(false);
    }

    public void HandleSelection(ShopItem shopItem)
    {
        _selectedShopItem = shopItem;
        select.gameObject.SetActive(true);

        if (shopItem.Sold)
        {
            select.RenderSelect();
            select.Subscribe(() => wardrobe.ChangeActiveSkin(shopItem.SkinOfFish));
        }
        else
        {
            var canBuy = bank.CanPurchase(_selectedShopItem.Price);

            select.RenderCondition(shopItem.Price,canBuy);
            select.Subscribe(confirmationMenu.EnableAndAnimate);
        }
    }

    public void Purchase()
    {
        bank.PurchaseItem(_selectedShopItem);
        RenderCells();
    }
    
    private void RenderCells()
    {
        foreach (var inventoryCell in _activeCells.Where(item => item.IsPurchased))
            inventoryCell.Render();
        
        foreach (var inventoryCell in _activeCells.Where(item => item.IsPurchased == false))
            inventoryCell.Render();
    }

    private void CreateCells()
    {
        foreach (var item in ItemCells)
        {
            ShopCell cell = Instantiate(cellPrefab, containerTransform);
            cell.SetInfo(item, this);
            _activeCells.Add(cell);
        }
    }
}