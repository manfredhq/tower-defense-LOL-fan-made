using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameEnded = false;

    // Update is called once per frame
    void Update()
    {
        if (isGameEnded == true)
        {
            return;
        }

        if (PlayerStats.lives <= 0)
        {
            isGameEnded = true;
            EndGame();
        }
    }

    private void EndGame()
    {
        Debug.Log("game over");
    }
}
