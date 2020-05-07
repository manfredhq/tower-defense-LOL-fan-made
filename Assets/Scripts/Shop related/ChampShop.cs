using UnityEngine;

public interface ChampShop
{
    Shop shop { get; set; }

    void Init(Shop shopGiven);
    GameObject GetGameObject();
}
