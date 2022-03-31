using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;

    private Vector3 _spawnPos = new Vector3(25, 0, 0);
    private PlayerController _playerController;
    private float _startDelay = 2f;
    private float _repeatRate = 2f;

    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacles", _startDelay, _repeatRate);
    }

    void Update()
    {
        
    }

    void SpawnObstacles()
    {
        if(_playerController.GameOver != true)
        {
            Instantiate(obstaclePrefab, _spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
