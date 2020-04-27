using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 200;
    public static int lives;
    public int startLives = 15;

    private void Start()
    {
        money = startMoney;
        lives = startLives;
    }
}
