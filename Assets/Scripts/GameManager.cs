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
    public GameObject titleScreen;
    private Vector3 spawnPos;
    public PlayerBehaviour playerBehaviourScript;
    public TextMeshProUGUI livesCount;
    public TextMeshProUGUI scoreCount;
    public TextMeshProUGUI timeCount;
    //public int timer;
    // public int difficulty = 5;
    private float spawn = 20;
    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        titleScreen.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            scoreCount.text = "Score: " + playerBehaviourScript.score;
            livesCount.text = "Lives: " + playerBehaviourScript.lives;
            timeCount.text  = "Time: "  + playerBehaviourScript.time;
        }
    }

    void SpawnObstacle()
    {
        spawnPos = new Vector3(Random.Range(-spawn, spawn), 1.5f, Random.Range(-spawn, spawn));
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }

    void SpawnCollectible()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawn, spawn), 0.5f, Random.Range(-spawn, spawn));
        Instantiate(collectiblePrefab, spawnPos, collectiblePrefab.transform.rotation);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        StartCoroutine(playerBehaviourScript.countdownTimer());
        for (int i = 0; i < difficulty; i++)
        {
            Invoke("SpawnObstacle", 0);
            Invoke("SpawnCollectible", 0);
            Invoke("SpawnCollectible", 0);
        }
    }
}
