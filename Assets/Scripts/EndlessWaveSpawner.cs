﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EndlessWaveSpawner : MonoBehaviour
{
    public int valueWave1 = 10;
    public int valueLastWave;
    public int valueThisWave;
    public int valueCurrentWave;


    public static int EnemiesAlives = 0;
    public Transform container;
    public Transform spawnPoint;
    public TMP_Text waveCountdownTimer;

    public GameManager gameManager;

    public float timeBetweenWaves = 7f;
    public float timeBetweenSpawn = .5f;

    public List<EnemyValue> enemies = new List<EnemyValue>();
    public float spawnRate = 2f;

    private List<EnemyValue> enemiesCanSpawn = new List<EnemyValue>();
    private int waveIndex = 0;
    public float countdown = 1f;
    private bool isWaveSpawnedEntierly = false;

    private void Start()
    {
        PlayerStats.waves = 0;
        isWaveSpawnedEntierly = false;
        valueCurrentWave = valueWave1;
        valueThisWave = valueCurrentWave;
        enemies.Sort(delegate (EnemyValue a, EnemyValue b)
        {
            return (a.value).CompareTo(b.value);
        });

        StartCoroutine(SpawnWave());
    }

    private void Update()
    {
        if (EnemiesAlives > 0)
        {
            GameManager.instance.SetFirstEnemy();
            return;
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
        float spawnRateModifier = Random.Range(-1f, 1f);
        float spawnRateModifiedNumber = spawnRateModifier;
        if (spawnRate + spawnRateModifier < 1)
        {
            spawnRateModifiedNumber = spawnRate - 1f;
            spawnRate = 1f;

        }
        else if (spawnRate + spawnRateModifier > 6)
        {
            spawnRateModifiedNumber = Mathf.Abs(spawnRate - 6);
            spawnRate = 6f;
        }
        else
        {
            spawnRate += spawnRateModifier;
        }
        Debug.Log(spawnRateModifier);
        Debug.Log(spawnRateModifiedNumber);
        valueCurrentWave -= Mathf.CeilToInt(spawnRateModifiedNumber * 10);

        do
        {
            enemiesCanSpawn = enemies.FindAll(delegate (EnemyValue enemy)
            {
                return enemy.value <= valueCurrentWave;
            });
            if (enemiesCanSpawn.Count != 0)
            {
                int rng = Random.Range(0, enemiesCanSpawn.Count);
                SpawnEnnemy(enemiesCanSpawn[rng]);
                yield return new WaitForSeconds(1f / spawnRate + (waveIndex / 20));
            }
        } while (enemiesCanSpawn.Count != 0);

        isWaveSpawnedEntierly = true;
        valueLastWave = valueThisWave;
        waveIndex++;
        countdown = timeBetweenWaves;
        WaveValueGain(valueLastWave);
        Debug.Log("Wave spawned entierly");
    }

    void SpawnEnnemy(EnemyValue enemy)
    {
        Instantiate(enemy.enemyPrefab, spawnPoint.position, spawnPoint.rotation, container);
        valueCurrentWave -= enemy.value;
        EnemiesAlives++;
    }

    void WaveValueGain(int lastWaveValue)
    {
        valueThisWave = Mathf.RoundToInt(Mathf.Pow(lastWaveValue, 1.2f) + 3);
        valueCurrentWave = valueThisWave;
    }
}

[System.Serializable]
public class EnemyValue
{

    public GameObject enemyPrefab;
    public int value;
}

