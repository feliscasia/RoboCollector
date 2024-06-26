using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour
{
    // Accessing the player's Rigidbody component
    private Rigidbody rb;

    public GameManager gameManager;

    // We need a score count and a lives count
    public int score;
    public int lives;
    public int time;
    public float rotateSpeed = 2;

    private float V = 0.2f;

    private void ResetGame()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    // The speed of the object as it moves
    [Range(0,12)]
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        // We need to access the Rigidbody component
        rb = GetComponent<Rigidbody>();
        
        score = 0;
        lives = 5;
        time = 120;
        StartCoroutine(countdownTimer());
    }

    void FixedUpdate()
    {
        if(gameManager.isGameActive)
        {
            var horizontalSpeed = Input.GetAxis("Horizontal") * speed;
            var frontSpeed = Input.GetAxis("Vertical") * speed;
            transform.LookAt(transform.position + rb.velocity);

            rb.AddForce(horizontalSpeed, 0, frontSpeed);
        }
    }

    public IEnumerator countdownTimer()
    {
        while (gameManager.isGameActive)
        {
            yield return new WaitForSeconds(1);
            time -= 1;
            if (time < 1)
            {
                gameManager.GetComponent<GameManager>().OutOfTime();
            }

            if (gameManager.numberOfCollectibles < 1)
            {
                gameManager.GetComponent<GameManager>().Victory();
            }
        }
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
                gameManager.GetComponent<GameManager>().GameOver();
            }
        }
    }
}
