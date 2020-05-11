using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLocalizerUI : MonoBehaviour
{

    TextMeshProUGUI textField;

    public string key;
    // Start is called before the first frame update
    void Start()
    {
        LocalizationSystem.Init();
        textField = GetComponent<TextMeshProUGUI>();
        string value = LocalizationSystem.GetLocalizedValue(key);
        textField.text = value;
    }

    public void Refresh()
    {
        LocalizationSystem.Init();
        textField = GetComponent<TextMeshProUGUI>();
        string value = LocalizationSystem.GetLocalizedValue(key);
        textField.text = value;
    }
}
