
using UnityEngine;


public class SkinsControll : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Shop shop;
    private GameObject _activeSkin;

    public GameObject CurrentSkin => _activeSkin;

    private void Awake()
    {
        _activeSkin = shop.ItemCells[PlayerPrefs.GetInt("fishSkinIndex")].SkinOfFish;
        // player.ChangePlayerSkin(_activeSkin);
    }

    public void ChangeActiveSkin(GameObject skin)
    {
        foreach (var item in shop.ItemCells)
        {
            if (item.SkinOfFish == skin)
            {
                PlayerPrefs.SetInt("fishSkinIndex", shop.ItemCells.IndexOf(item));
                // player.ChangePlayerSkin(skin);
                return;
            }
        }
    }
}