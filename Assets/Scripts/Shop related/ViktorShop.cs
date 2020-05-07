using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViktorShop : MonoBehaviour, ChampShop
{
    public Shop shop { get; set; }

    public void OnClick()
    {
        shop.SelectViktor();
    }

    public void Init(Shop shopGiven)
    {
        shop = shopGiven;
    }
}
