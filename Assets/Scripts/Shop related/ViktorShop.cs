using UnityEngine;

public class ViktorShop : MonoBehaviour, ChampShop
{
    public Shop shop { get; set; }

    public void OnClick()
    {
        shop.SelectViktor(this);
    }

    public void Init(Shop shopGiven)
    {
        shop = shopGiven;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
