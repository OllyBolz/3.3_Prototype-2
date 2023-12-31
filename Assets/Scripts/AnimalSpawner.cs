using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private GameObject chosenChick;

    private float spawn = 19f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1f || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Q)) //Also made it 'Q' on the keyboard
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            
            int side = Random.Range(0, 4);

            switch (side)
            {
                case 0://Top
                    Instantiate(animalPrefabs[animalIndex], new Vector3(Random.Range(-spawn, spawn), 0, spawn), Quaternion.Euler(0f, 180f, 0f));
                    break;
                case 1://Bottom
                    Instantiate(animalPrefabs[animalIndex], new Vector3(Random.Range(-spawn, spawn), 0, -spawn), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 2://Left
                    Instantiate(animalPrefabs[animalIndex], new Vector3(-spawn, 0, Random.Range(-spawn, spawn)), Quaternion.Euler(0f, 90f, 0f));
                    break;
                case 3://Right
                    Instantiate(animalPrefabs[animalIndex], new Vector3(spawn, 0, Random.Range(-spawn, spawn)), Quaternion.Euler(0f, 270f, 0f));
                    break;
            }
            timer = 0f;
        }
    }
}
