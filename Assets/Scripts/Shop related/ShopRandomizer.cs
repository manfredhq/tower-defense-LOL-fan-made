using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopRandomizer : MonoBehaviour
{
    public ShopBlueprint[] shopTurret;
    public int nbTurret;

    public Shop shop;
    private void Start()
    {
        Roll();
    }

    void Roll()
    {
        //TODO: change the way it work, I'm busy and it's late
        for (int i = 0; i < nbTurret; i++)
        {
            int random = Random.Range(0, shopTurret.Length);
            GameObject obj = Instantiate(shopTurret[random].shopPrefab, transform);
            //SetupButton(obj.GetComponent<Button>(), shopTurret[random].name);
            //obj.GetComponent<Button>().onClick.AddListener(delegate () { shopTurret[random].function.Invoke(); });

            //obj.GetComponent<Button>().onClick.AddListener(() => { shopTurret[random].function.in; });

        }

    }

    void SetupButton(Button obj, string name)
    {
        if (name == "jinx")
        {
            obj.onClick.AddListener(delegate () { shop.SelectJinx(); });
        }
        else if (name == "viktor")
        {
            obj.onClick.AddListener(() => { shop.SelectViktor(); });
        }
        else if (name == "tristana")
        {
            obj.onClick.AddListener(delegate () { shop.SelectTristana(); });
        }
    }
}
