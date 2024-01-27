using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private float timeBewteenSpawns;
    private float difficultyIncreaseRate;
    private float timeUntilSpawn;
    private float timeUntilWave;
    private int waveNumber;
    // Start is called before the first frame update
    
    
    void Start()
    {
        timeUntilWave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilWave -= Time.deltaTime;
        if (!(timeUntilWave <= 0)) return;
        timeUntilWave = timeBetweenWaves;
        SpawnWave();
    }

    private void SpawnWave()
    {
        waveNumber++;
        
    }
}
