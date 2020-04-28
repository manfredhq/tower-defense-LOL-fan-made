using UnityEngine;
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
            waveCountdownTimer.text = "0";
        }
        else
        {
            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

            waveCountdownTimer.text = string.Format("{0:00.00}", countdown);
        }

    }

    IEnumerator SpawnWave()
    {
        isSpawning = true;
        waveIndex++;
        PlayerStats.waves++;
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
