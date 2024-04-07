using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Camera follows the player

public class CameraBehaviour : MonoBehaviour
{
    public float zBarrier = -25.0f;

    [Tooltip("Where is the camera looking?")]
    public Transform target;

    [Tooltip("Offset between the camera and the player")]
    public Vector3 offset = new Vector3(0, 2, -5);

    // Update is called once per frame
    void Update()
    {
        // Is the target a valid object?
        if (target != null)
        {
            transform.position = target.position + offset;

            if (transform.position.z < zBarrier)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zBarrier);
            }

            // Rotate the camera to look at the player
            transform.LookAt(target);
        }
    }
}
