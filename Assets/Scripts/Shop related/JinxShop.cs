using UnityEngine;

public class JinxShop : MonoBehaviour, ChampShop
{
    public Shop shop { get; set; }

    public void OnClick()
    {
        shop.SelectJinx(this);
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
