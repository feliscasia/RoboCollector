using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleBehaviour : MonoBehaviour
{
    private void ResetGame()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    private float V = 0.5f;

    public int lives;

    // Start is called before the first frame update
    void Start()
    {
        lives = 5;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Did the obstacle collide with the player?
        if (collision.gameObject.GetComponent <PlayerBehaviour>())
        {
            // Decrease lives by 1
            lives = lives - 1;
            if (lives < 1)
            {
                Invoke("ResetGame", V);
            }
        }
    }
}
