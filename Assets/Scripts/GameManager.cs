using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameEnded;
    public GameObject gameOverUI;
    public GameObject completeLevelUI;


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
        isGameEnded = true;
        completeLevelUI.SetActive(true);
    }

    public bool GetGameStatus()
    {
        return isGameEnded;
    }
}
