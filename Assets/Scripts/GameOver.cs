using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public SceneFader sceneFader;

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
