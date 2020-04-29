using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameEnded;
    public GameObject gameOverUI;
    public string nextLevelName = "Level2Scene";
    public int levelToUnlock = 2;
    public SceneFader sceneFader;


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

    public void WinLevel()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevelName);
    }
}
