using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Exercise 3, 100 objects to be spawned at random positions. (1)
    [SerializeField] private GameObject objectToSpawn;
    public int numberOfObjectsToSpawn = 100;

    // Range of the random positions. Should be within the level bounds.


    void Start()
    {
        // Spawn numberOfObjectsToSpawn objects at random positions (1)
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10, 10), Random.Range(0, 10), Random.Range(0, 20));
            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
        }
    }
}
