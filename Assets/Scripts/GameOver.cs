using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text wavesText;

    public SceneFader sceneFader;

    private void OnEnable()
    {
        wavesText.text = PlayerStats.waves.ToString();
    }

    public void Retry()
    {
        WaveSpawner.EnemiesAlives = 0;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void GotoMenu()
    {
        WaveSpawner.EnemiesAlives = 0;
        sceneFader.FadeTo("Menu");
    }
}
