using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject collectiblePrefab;
    private Vector3 spawnPos;
    private float startDelay = 0.1f;
    private PlayerBehaviour playerBehaviourScript;
    public int difficultyLevel = 5;
    private float spawn = 20;

    // Start is called before the first frame update
    void Start()
    {
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
