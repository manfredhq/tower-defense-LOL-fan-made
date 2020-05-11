using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public string[] dialogKeys;
    public TextLocalizerUI dialogText;
    public GameObject dialogCanvas;

    private int dialogIndex = 0;

    private void Start()
    {
        Toggle();
        dialogText.key = dialogKeys[dialogIndex];
        dialogText.Refresh();
    }

    public void NextDialog()
    {
        if (dialogIndex < dialogKeys.Length - 1)
        {
            dialogIndex++;
            dialogText.key = dialogKeys[dialogIndex];
            dialogText.Refresh();
            Debug.Log("next dialog");
        }
        else
        {
            Toggle();
            Debug.Log("No more dialog");
        }
    }
    public void Toggle()
    {
        dialogCanvas.SetActive(!dialogCanvas.activeSelf);

        if (dialogCanvas.activeSelf)
        {
            GameManager.instance.GetComponent<WaveSpawner>().PauseCountdown(true);
        }
        else
        {
            GameManager.instance.GetComponent<WaveSpawner>().PauseCountdown(false);

        }
    }
}
