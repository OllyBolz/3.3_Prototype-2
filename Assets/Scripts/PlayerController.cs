using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float forwardInput;
    private float speed = 10f;
    private float xRange = 15f;
    private float zRange = 15f;
    public GameObject projectilePrefab;

    public int score = 0;
    private int scoreTrack = -1;
    public int lives = 3;
    private int livesTrack = -1;


    void Update()
    {
        if (lives != livesTrack)
        {
            if (lives > 0)
            {
                Debug.Log("Lives: " + lives.ToString());
                livesTrack = lives;
            }
            else if (lives == 0)
            {
                Debug.Log("Game Over");
            }
            else if (lives < 0)
            {
                Debug.Log("Dude you lost, call it quits. XD");
            }
        }

        if (score != scoreTrack)
        {
            Debug.Log("Score: " + score.ToString());
            scoreTrack = score;
        }

        //Pizza
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }

        //Keep Player in bounds
        if (transform.position.z < -zRange) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        //Inputs
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.position += new Vector3(horizontalInput, 0 ,forwardInput) *  speed * Time.deltaTime;

        if (horizontalInput > 0f)//Right
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (horizontalInput < 0f)//Left
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }

        if (forwardInput > 0f)//Up
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (forwardInput < 0f)//Down
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }


    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Chicken"))
        {
            Debug.Log("Game Over");
        }
    }
}
