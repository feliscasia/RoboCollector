using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehaviour : MonoBehaviour
{
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Did the collectible collide with the player
        if (collision.gameObject.GetComponent <PlayerBehaviour>())
        {
            // Increase score by 500
            score = score + 500;
        }
    }
}
