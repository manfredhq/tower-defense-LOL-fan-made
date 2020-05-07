using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JinxShop : MonoBehaviour, ChampShop
{
    public Shop shop { get; set; }

    public void OnClick()
    {
        shop.SelectJinx();
    }

    public void Init(Shop shopGiven)
    {
        shop = shopGiven;
    }
}
