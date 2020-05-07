using UnityEngine;

public class RollButton : MonoBehaviour
{
    public ShopRandomizer randomizer;
    public void OnClick()
    {
        if (PlayerStats.money < 100)
        {
            Debug.Log("not enough money");
        }
        else
        {
            PlayerStats.money -= 100;
            randomizer.Roll();
        }
    }
}
