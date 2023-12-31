using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed = 10f;
    private float xBounds = 30f;
    private float zBounds = 20f;

    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("/Player").GetComponent<PlayerController>();
        
        if (this.gameObject.CompareTag("Pizza"))
        {
            speed *= 2f;
        } 
    }

    void Update()
    {

        if (transform.position.x < -xBounds || transform.position.x > xBounds || transform.position.z < -zBounds || transform.position.z > zBounds)
        {
            Destroy(gameObject);
            if (this.gameObject.CompareTag("Pizza"))
            {
                playerController.score -= 30;
            }
        }

        transform.Translate(Vector3.forward * Time.deltaTime * speed); 
    }
}
