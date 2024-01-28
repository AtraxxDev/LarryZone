using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private float timeBewteenSpawns;
    [SerializeField] private List<Transform> spawnPoints; // Cambiado a lista de Transforms
    private float difficultyIncreaseRate;
    private float timeUntilSpawn;
    private float timeUntilWave;
    private int waveNumber;
    private int noOfEnemies;
    [SerializeField] private TextMeshProUGUI waveText;
    private float randomEnemyTime;

    void Start()
    {
        timeUntilWave = 0;
        timeUntilSpawn = 0;
        difficultyIncreaseRate = 0.5f;
        noOfEnemies = 4;
    }

    void Update()
    {
        timeUntilWave -= Time.deltaTime;
        if (timeUntilWave > 0)
        {
            SpawnWave();
        }
        else if (timeUntilWave <= 0)
        {
            ChangeWave();
        }

        int waveInt = (int)math.round(timeUntilWave);
        waveText.color = waveInt switch
        {
            8 or 6 or 4 => Color.yellow,
            7 or 5 or 3 => Color.white,
            <= 2 => Color.red,
            _ => Color.white
        };
        waveText.text = " wave " + waveNumber;
    }

    private void SpawnWave()
    {
        if (timeUntilSpawn <= 0)
        {
            timeUntilSpawn = timeBewteenSpawns;
            SpawnEnemy();
            switch (randomEnemyTime)
            {
                case <= 0:
                    {
                        var randomEnemyNumber = Random.Range(0, noOfEnemies);
                        SpawnEnemies(randomEnemyNumber);
                        randomEnemyTime = Random.Range(0.5f, timeBewteenSpawns);
                        break;
                    }
                case > 0:
                    randomEnemyTime--;
                    break;
            }

        }
        else
        {
            timeUntilSpawn -= Time.deltaTime;
        }

    }
    private void ChangeWave()
    {
        timeUntilWave = timeBetweenWaves;
        waveNumber++;
        if (timeBewteenSpawns > 0.5f)
        {
            timeBewteenSpawns -= difficultyIncreaseRate;
            if (waveNumber > 6)
            {
                noOfEnemies += 6;
            }
            else
            {
                noOfEnemies += 2;
            }

        }

    }
    private void SpawnEnemy()
    {
        var randomIndex = Random.Range(0, spawnPoints.Count);
        var randomPoint = spawnPoints[randomIndex].position;

        // Ajusta el volteo del sprite solo si está en el lado positivo del eje X
        bool shouldFlip = randomPoint.x > transform.position.x;

        var randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Instantiate(randomEnemyPrefab, randomPoint, Quaternion.identity);

        

    }
    private void SpawnEnemies(int noOfEnemies)
    {
        for (int i = 0; i < noOfEnemies; i++)
        {
            SpawnEnemy();
        }
    }
}
