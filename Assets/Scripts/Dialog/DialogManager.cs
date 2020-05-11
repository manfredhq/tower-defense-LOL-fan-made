using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public List<DialogOptions> dialogs = new List<DialogOptions>();
    public TextLocalizerUI dialogText;
    public GameObject dialogCanvas;

    public WaveSpawner waveSpawner;

    public DialogOptions.currentState nextDialogState;


    public int dialogIndex = 0;

    private void Start()
    {
        dialogs.Sort(delegate (DialogOptions a, DialogOptions b)
        {
            return (a.waveIndexToStart).CompareTo(b.waveIndexToStart);
        });
        var temp = new DialogOptions();
        temp.InitLast();
        dialogs.Add(temp);
        if (dialogs[dialogIndex].state == DialogOptions.currentState.Start)
        {
            Toggle(true);
            dialogText.key = dialogs[dialogIndex].key;
            dialogText.Refresh();
        }

        nextDialogState = dialogs[dialogIndex + 1].state;
    }





    public void NextDialog()
    {
        if (nextDialogState == DialogOptions.currentState.Follow)
        {
            dialogIndex++;
            dialogText.key = dialogs[dialogIndex].key;
            dialogText.Refresh();
            Debug.Log("next dialog");
        }
        else
        {
            Toggle(false);
        }
        nextDialogState = dialogs[dialogIndex + 1].state;
        /*if (dialogs[dialogIndex + 1].state == DialogOptions.currentState.Start)
        {
            nextDialogState = DialogOptions.currentState.Start;
            if (dialogIndex < dialogs.Length - 1)
            {
                dialogIndex++;
                dialogText.key = dialogs[dialogIndex].key;
                dialogText.Refresh();
                Debug.Log("next dialog");
            }
            else
            {
                Toggle();
                Debug.Log("No more dialog");
            }
        }
        else if (dialogs[dialogIndex + 1].state == DialogOptions.currentState.BeforeWave)
        {
            nextDialogState = DialogOptions.currentState.BeforeWave;
        }
        else if (dialogs[dialogIndex + 1].state == DialogOptions.currentState.WaveEntierlySpawned)
        {
            nextDialogState = DialogOptions.currentState.WaveEntierlySpawned;
        }*/

    }

    private void Update()
    {
        if (nextDialogState == DialogOptions.currentState.BeforeWave)
        {
            if (dialogs[dialogIndex + 1].waveIndexToStart == waveSpawner.waveIndex)
            {
                dialogIndex++;
                dialogText.key = dialogs[dialogIndex].key;
                dialogText.Refresh();
                Toggle(false);
                nextDialogState = dialogs[dialogIndex + 1].state;

            }
        }
    }

    public void OnWaveEntierlySpawned()
    {
        dialogIndex++;
        dialogText.key = dialogs[dialogIndex].key;
        dialogText.Refresh();
        nextDialogState = dialogs[dialogIndex + 1].state;
        Toggle(false);
    }
    public void Toggle(bool isStart)
    {
        dialogCanvas.SetActive(!dialogCanvas.activeSelf);
        if (isStart)
            if (dialogCanvas.activeSelf)
            {
                GameManager.instance.GetComponent<WaveSpawner>().PauseCountdown(true);
            }
            else
            {
                GameManager.instance.GetComponent<WaveSpawner>().PauseCountdown(false);

            }
        else
        {
            if (dialogCanvas.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
                GameManager.instance.GetComponent<WaveSpawner>().PauseCountdown(false);
            }
        }
    }
}
