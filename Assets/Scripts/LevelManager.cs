using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Exercise 3
    public static LevelManager instance;

    [SerializeField] private List<Transform> pointsToMoveTo; // Set these with the inspector, to allow designers to freely move and visualise the points.
    [SerializeField] private Transform playerStart; // Where the player starts on the level

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        // find player object by tag, or we can use a reference to the player object if we have it through a singleton. Done this as I am unhappy having the player prefab have empty elements that should be passed in by the level
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        MainPlayer playerScript = player.GetComponent<MainPlayer>();
        playerScript.SetPointsToMoveTo(pointsToMoveTo);
    }
}
