using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject emenyPrefab;
    [SerializeField] private GameObject powerupPrefab;

    private float _spawnRange = 9f;
    private int _enemyCount;
    private int _waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(_waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        _enemyCount = FindObjectsOfType<EmenyController>().Length;

        if(_enemyCount == 0)
        {
            _waveNumber++;
            SpawnEnemyWave(_waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }
    
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(emenyPrefab, GenerateSpawnPosition(), emenyPrefab.transform.rotation);
        }
    }
    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-_spawnRange, _spawnRange);
        float spawnPosZ = Random.Range(-_spawnRange, _spawnRange);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }

}
