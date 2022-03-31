using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int pointValue;
    [SerializeField] private ParticleSystem explotionParticle;
    private Rigidbody _targetRb;
    private GameManager _gameManager;
    private float _minSpeed = 12f;
    private float _maxSpeed = 16f;
    private float _maxTorque = 10f;
    private float _xRange = 4f;
    private float _ySpawnPos = -2f;



    // Start is called before the first frame update
    void Start()
    {
        _targetRb = GetComponent<Rigidbody>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        _targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        _targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown() {
        if(_gameManager.IsGameActive)
        {
            Destroy(gameObject);
            Instantiate(explotionParticle, transform.position, explotionParticle.transform.rotation);
            _gameManager.UpdateScore(pointValue);
        }
    }
    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
            _gameManager.GameOver();
        }
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-_xRange, _xRange), _ySpawnPos);
    }
    float RandomTorque()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }
}
