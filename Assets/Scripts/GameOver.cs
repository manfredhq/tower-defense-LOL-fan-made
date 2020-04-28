using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text wavesText;

    private void OnEnable()
    {
        wavesText.text = PlayerStats.waves.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
