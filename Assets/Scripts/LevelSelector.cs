using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButtons;

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        Debug.Log(levelReached);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
            else
            {
                levelButtons[i].interactable = true;
            }

        }
    }
    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }
}
