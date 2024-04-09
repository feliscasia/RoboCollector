using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehaviour : MonoBehaviour
{
    public ObstacleBehaviour obstacleBehaviourScript;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
