using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour
{
    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("/Player").GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Chicken"))
        {
            playerController.score += 100;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
