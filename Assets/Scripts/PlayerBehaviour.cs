using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour
{
    // Accessing the player's Rigidbody component
    private Rigidbody rb;

    // We need a score count and a lives count
    public int score;
    public int lives;

    private float V = 0.2f;

    private void ResetGame()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    // The speed of the ball as it moves
    [Range(0,12)]
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        // We need to access the Rigidbody component
        rb = GetComponent<Rigidbody>();

        score = 0;

        lives = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var horizontalSpeed = Input.GetAxis("Horizontal") * speed;
        var frontSpeed = Input.GetAxis("Vertical") * speed;

        rb.AddForce(horizontalSpeed, 0, frontSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            score = score + 500;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            lives = lives - 1;
            score = score - 20;
            if (lives < 1)
            {
                Invoke("ResetGame", V);
            }
        }
    }
}
