using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameEnded;
    public GameObject gameOverUI;


    private void Start()
    {
        isGameEnded = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isGameEnded == true)
        {
            return;
        }

        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        isGameEnded = true;
        gameOverUI.SetActive(true);
    }
}
