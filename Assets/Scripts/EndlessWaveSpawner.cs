using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class EndlessWaveSpawner : MonoBehaviour
{
    public int valueWave1 = 10;
    public int valueLastWave;
    public int valueCurrentWave;

    public static int EnemiesAlives = 0;
    public Transform container;
    public Transform spawnPoint;
    public TMP_Text waveCountdownTimer;

    public GameManager gameManager;

    public float timeBetweenWaves = 7f;
    public float timeBetweenSpawn = .5f;

    public List<EnemyValue> enemies = new List<EnemyValue>();

    private List<EnemyValue> enemiesCanSpawn = new List<EnemyValue>();

    private void Start()
    {
        valueCurrentWave = valueWave1;
        enemies.Sort(delegate (EnemyValue a, EnemyValue b)
        {
            return (a.value).CompareTo(b.value);
        });

        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
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
                yield return new WaitForSeconds(1f);
            }
        } while (enemiesCanSpawn.Count != 0);

        Debug.Log("Wave spawned entierly");
    }

    void SpawnEnnemy(EnemyValue enemy)
    {
        Instantiate(enemy.enemyPrefab, spawnPoint.position, spawnPoint.rotation, container);
        valueCurrentWave -= enemy.value;
    }
}

[System.Serializable]
public class EnemyValue
{

    public GameObject enemyPrefab;
    public int value;
}

