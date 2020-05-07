using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopRandomizer : MonoBehaviour
{
    public ShopBlueprint[] shopTurret;
    public int nbTurret;

    public Shop shop;
    public ChampShop[] champShop;

    private List<GameObject> turretList = new List<GameObject>();
    private void Start()
    {
        Roll();
    }

    public void Roll()
    {
        foreach (GameObject turret in turretList)
        {
            Destroy(turret);
        }
        //TODO: change the way it work, I'm busy and it's late
        for (int i = 0; i < nbTurret; i++)
        {
            int random = Random.Range(0, shopTurret.Length);
            GameObject obj = Instantiate(shopTurret[random].shopPrefab, transform);
            turretList.Add(obj);
            obj.GetComponent<ChampShop>().Init(shop);

        }

    }
}
