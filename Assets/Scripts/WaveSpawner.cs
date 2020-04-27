﻿using UnityEngine;
using TMPro;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Transform container;
    public Transform spawnPoint;
    public TMP_Text waveCountdownTimer;
    public Transform ennemyPrefab;
    public float timeBetweenWaves = 7f;
    private float countdown = 2f;
    private int waveIndex = 0;
    private bool isSpawning = false;
    private void Update()
    {
        if (countdown <= 0f && isSpawning == false)
        {
            StartCoroutine(SpawnWave());

        }
        if (isSpawning == false)
        {
            countdown -= Time.deltaTime;
        }
        if (isSpawning == true)
        {
            waveCountdownTimer.text = "Wave Spawning";
        }
        else
        {
            waveCountdownTimer.text = Mathf.Round(countdown).ToString();
        }

    }

    IEnumerator SpawnWave()
    {
        isSpawning = true;
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnnemy();
            yield return new WaitForSeconds(1f);
        }
        isSpawning = false;
        countdown = timeBetweenWaves;
    }

    void SpawnEnnemy()
    {
        Instantiate(ennemyPrefab, spawnPoint.position, spawnPoint.rotation, container);
    }
}
