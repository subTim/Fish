using UnityEngine;


[CreateAssetMenu(menuName = "ShopItem")]
public class ShopItem : ScriptableObject, IItemFunc
{
    [SerializeField] private bool sold = false;
    [SerializeField] private int price;
    [SerializeField] private Sprite image;
    [SerializeField] private GameObject skinOfFish;

    public Sprite Image => image;
    public GameObject SkinOfFish => skinOfFish;
    public int Price => price;
    public bool Sold => sold;
    public void Sell() => sold = true;
}
