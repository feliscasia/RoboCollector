using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleBehaviour : MonoBehaviour
{
    public float speed = 0.8f;
    private Rigidbody enemyRb;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
    }
}
