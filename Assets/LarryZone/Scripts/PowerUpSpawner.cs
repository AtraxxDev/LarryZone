using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<GameObject> powerUpPrefabs;
    [SerializeField] private float spawnInterval = 10f;
    [SerializeField] private float powerUpDuration = 7f;

    private void Start()
    {
        StartCoroutine(SpawnPowerUps());
    }

    private IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Elegir aleatoriamente un transform de la lista
            int spawnPointIndex = Random.Range(0, spawnPoints.Count);
            Transform spawnPoint = spawnPoints[spawnPointIndex];

            // Elegir aleatoriamente un power-up de la lista
            int powerUpIndex = Random.Range(0, powerUpPrefabs.Count);
            GameObject powerUpPrefab = powerUpPrefabs[powerUpIndex];

            // Instanciar el power-up en el transform seleccionado
            GameObject powerUpInstance = Instantiate(powerUpPrefab, spawnPoint.position, Quaternion.identity);

            // Programar la destrucción después del tiempo de duración
            Destroy(powerUpInstance, powerUpDuration);
        }
    }
}
