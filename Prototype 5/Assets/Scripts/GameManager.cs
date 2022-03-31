using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button restartButton;
    [SerializeField] private GameObject titleScreen;

    private int _score;
    private float _spawnRange = 1f;
    private bool _isGameActive;

    public bool IsGameActive
    {
        get => _isGameActive;
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(_isGameActive)
        {
            yield return new WaitForSeconds(_spawnRange);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        scoreText.text = $"Score: {_score}";
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        _isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        _isGameActive = true;
        _score = 0;
        _spawnRange /= difficulty;

        UpdateScore(0);
        StartCoroutine(SpawnTarget());

        titleScreen.gameObject.SetActive(false);
    }
}
