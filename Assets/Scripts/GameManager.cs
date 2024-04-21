using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject collectibleOnePrefab;
    public GameObject collectibleTwoPrefab;
    public GameObject collectibleThreePrefab;
    public GameObject titleScreen;
    public GameObject gameOver;
    public GameObject outOfTime;
    public GameObject victory;
    public Button gameOverRestart;
    public Button outOfTimeRestart;
    public Button victoryRestart;
    private Vector3 spawnPos;
    public PlayerBehaviour playerBehaviourScript;
    public TextMeshProUGUI livesCount;
    public TextMeshProUGUI scoreCount;
    public TextMeshProUGUI timeCount;
    private float spawn = 20;
    public bool isGameActive;
    public int numberOfCollectibles;

    // Start is called before the first frame update
    void Start()
    {
        titleScreen.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
        outOfTime.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            numberOfCollectibles = FindObjectsOfType<CollectibleBehaviour>().Length;
            scoreCount.text = "Score: " + playerBehaviourScript.score;
            livesCount.text = "Lives: " + playerBehaviourScript.lives;
            timeCount.text  = "Time: "  + playerBehaviourScript.time;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void SpawnObstacle()
    {
        spawnPos = new Vector3(Random.Range(-spawn, spawn), 1, Random.Range(-spawn, spawn));
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }

    void SpawnCollectibleOne()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawn, spawn), 0.5f, Random.Range(-spawn, spawn));
        Instantiate(collectibleOnePrefab, spawnPos, collectibleOnePrefab.transform.rotation);
    }

    void SpawnCollectibleTwo()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawn, spawn), 0.5f, Random.Range(-spawn, spawn));
        Instantiate(collectibleTwoPrefab, spawnPos, collectibleTwoPrefab.transform.rotation);
    }

    void SpawnCollectibleThree()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawn, spawn), 0.5f, Random.Range(-spawn, spawn));
        Instantiate(collectibleThreePrefab, spawnPos, collectibleThreePrefab.transform.rotation);
    }

    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void OutOfTime()
    {
        outOfTime.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void Victory()
    {
        victory.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        StartCoroutine(playerBehaviourScript.countdownTimer());
        for (int i = 0; i < difficulty; i++)
        {
            Invoke("SpawnObstacle", 0);
            Invoke("SpawnCollectibleOne", 0);
            Invoke("SpawnCollectibleTwo", 0);
            Invoke("SpawnCollectibleThree", 0);
        }
    }
}
