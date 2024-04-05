using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour
{
    // The player has a Rigidbody component
    private Rigidbody rb;

    // The speed of the ball as it moves
    [Tooltip("The speed of the ball as it moves")]
    [Range(0,12)]
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        // We need to access the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var horizontalSpeed = Input.GetAxis("Horizontal") * speed;
        var frontSpeed = Input.GetAxis("Vertical") * speed;

        rb.AddForce(horizontalSpeed, 0, frontSpeed);
    }
}
