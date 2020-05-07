using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ChampShop
{
    Shop shop { get; set; }

    void Init(Shop shopGiven);
}
