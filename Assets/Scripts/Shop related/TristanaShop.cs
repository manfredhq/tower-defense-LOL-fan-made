using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TristanaShop : MonoBehaviour, ChampShop
{
    public Shop shop { get; set; }

    public void OnClick()
    {
        shop.SelectTristana();
    }

    public void Init(Shop shopGiven)
    {
        shop = shopGiven;
    }
}
