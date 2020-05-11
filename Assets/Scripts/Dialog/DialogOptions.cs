using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class DialogOptions
{
    public enum currentState
    {
        Start,
        BeforeWave,
        WaveEntierlySpawned,
        Follow,
        None
    }

    public string key;

    public currentState state = currentState.Start;

    public int waveIndexToStart;

    public void InitLast()
    {
        state = currentState.None;
    }
}
