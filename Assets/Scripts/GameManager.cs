using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject collectiblePrefab;
    private Vector3 spawnPos;
    public PlayerBehaviour playerBehaviourScript;
    public TextMeshProUGUI livesCount;
    public TextMeshProUGUI scoreCount;
    public TextMeshProUGUI timeCount;
    public int timer;
    public int difficultyLevel = 5;
    private float spawn = 20;
    private float startDelay = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 120;
        for (int i = 0; i < difficultyLevel; i++)
        {
            Invoke("SpawnObstacle", 0);
            Invoke("SpawnCollectible", 0);
            Invoke("SpawnCollectible", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreCount.text = "Score: " + playerBehaviourScript.score;
        livesCount.text = "Lives: " + playerBehaviourScript.lives;
    }

    void SpawnObstacle()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawn, spawn), 1.5f, Random.Range(-spawn, spawn));
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }

    void SpawnCollectible()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawn, spawn), 0.5f, Random.Range(-spawn, spawn));
        Instantiate(collectiblePrefab, spawnPos, collectiblePrefab.transform.rotation);
    }
}
