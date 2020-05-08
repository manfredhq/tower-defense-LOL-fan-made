using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlives = 0;
    public Transform container;
    public Transform spawnPoint;
    public TMP_Text waveCountdownTimer;

    public GameManager gameManager;

    public float timeBetweenWaves = 7f;
    public float timeBetweenSpawn = .5f;

    public Wave[] waves;
    private float countdown = 2f;
    private int waveIndex = 0;
    private void Update()
    {
        if (EnemiesAlives > 0)
        {
            return;
        }
        if (waveIndex == waves.Length && !gameManager.GetGameStatus())
        {
            //End Level
            gameManager.WinLevel();
            Debug.Log("Level complete");
            this.enabled = false;

        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownTimer.text = string.Format("{0:00.00}", countdown);


    }

    IEnumerator SpawnWave()
    {
        PlayerStats.waves++;

        Wave wave = waves[waveIndex];
        List<PreciseWave> subWavesToSpawn = new List<PreciseWave>();

        foreach (PreciseWave subWaves in wave.subWaves)
        {
            EnemiesAlives += subWaves.count;
            subWavesToSpawn.Add(subWaves);
        }

        foreach (PreciseWave subWave in wave.subWaves)
        {
            yield return new WaitForSeconds(subWave.startSpawn);
            StartCoroutine(SpawnSubWave(subWave));

        }

        waveIndex++;
        countdown = timeBetweenWaves;


    }

    IEnumerator SpawnSubWave(PreciseWave subWave)
    {
        for (int i = 0; i < subWave.count; i++)
        {
            SpawnEnnemy(subWave.enemyPrefab);
            yield return new WaitForSeconds(1f / subWave.spawnRate);
        }
    }

    void SpawnEnnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation, container);
    }
}
