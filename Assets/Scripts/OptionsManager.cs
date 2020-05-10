using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    public void SetLanguageFrench()
    {
        LocalizationSystem.ChangeLanguage(LocalizationSystem.Language.French);
        PlayerPrefs.SetString("language", "fr");
    }

    public void SetLanguageEnglish()
    {
        LocalizationSystem.ChangeLanguage(LocalizationSystem.Language.English);
        PlayerPrefs.SetString("language", "en");
    }

    public void CloseOptions()
    {
        gameObject.SetActive(false);
    }
}
