using UnityEngine;
public class MainMenu : MonoBehaviour
{

    public string levelToLoad = "Level1Scene";
    public SceneFader sceneFader;
    public GameObject OptionsCanvas;

    private void Start()
    {
        string language = PlayerPrefs.GetString("language", "en");
        if (language == "en") { LocalizationSystem.language = LocalizationSystem.Language.English; }
        else if (language == "fr") { LocalizationSystem.language = LocalizationSystem.Language.French; }
        Debug.Log(language);
    }
    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exciting");
        Application.Quit();
    }

    public void OpenOptions()
    {
        OptionsCanvas.SetActive(true);
    }
}
