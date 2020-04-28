using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 200;
    public static int lives;
    public int startLives = 15;
    public static int waves;

    private void Start()
    {
        waves = 0;
        money = startMoney;
        lives = startLives;
    }
}
