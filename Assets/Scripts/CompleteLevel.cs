using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;

    public string nextLevelName = "Level2Scene";
    public int levelToUnlock = 2;

    public void GotoMenu()
    {
        WaveSpawner.EnemiesAlives = 0;
        sceneFader.FadeTo("Menu");
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevelName);
    }
}
