using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehaviour : MonoBehaviour
{
    public ObstacleBehaviour obstacleBehaviourScript;
    public float speed = 0.01f;
    private Rigidbody collectibleRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        collectibleRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        collectibleRb.AddForce((player.transform.position - transform.position).normalized * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Did the collectible collide with the player
        if (collision.gameObject.GetComponent <PlayerBehaviour>())
        {
            Destroy(gameObject);
        }
    }
}
