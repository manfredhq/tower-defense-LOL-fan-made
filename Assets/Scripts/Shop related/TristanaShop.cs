using UnityEngine;

public class TristanaShop : MonoBehaviour, ChampShop
{
    public Shop shop { get; set; }

    public void OnClick()
    {
        shop.SelectTristana(this);
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
