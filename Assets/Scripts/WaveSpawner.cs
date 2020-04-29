using UnityEngine;
using TMPro;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlives = 0;
    public Transform container;
    public Transform spawnPoint;
    public TMP_Text waveCountdownTimer;



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

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(1f / wave.spawnRate);
        }
        waveIndex++;
        countdown = timeBetweenWaves;

        if (waveIndex == waves.Length)
        {
            //End Level
            Debug.Log("Level complete");
            this.enabled = false;
        }
    }

    void SpawnEnnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation, container);
        EnemiesAlives++;
    }
}
