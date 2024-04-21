using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleBehaviour : MonoBehaviour
{
    public float speed = 0.8f;
    private Rigidbody enemyRb;
    public GameObject player;
    public Transform target;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (gameManager.isGameActive)
        {
            transform.LookAt(target);
            enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
        }
    }
}
