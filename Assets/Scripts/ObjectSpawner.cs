using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Exercise 3, 100 objects to be spawned at random positions. (1)
    [SerializeField] private GameObject objectToSpawn;
    public int numberOfObjectsToSpawn = 100;

    // Range of the random positions. Should be within the level bounds.
    [SerializeField] private BoxCollider spawnerBounds;

    void Start()
    {
       SpawnAll();
    }
    private void SpawnAll()
    {
        Bounds bounds = spawnerBounds.bounds; // Found under the Floor/SpawnerBounds object in the scene. This is a box collider that will be used to spawn objects within its bounds

        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z));
            Instantiate(objectToSpawn, randomPosition, Quaternion.identity, spawnerBounds.transform);
        }
    }

    public void Reset()
    {
        // Remove all objects spawned by this spawner (1)
        foreach (Transform child in spawnerBounds.transform)
        {
            Destroy(child.gameObject);
        }
        SpawnAll();
    }
}
