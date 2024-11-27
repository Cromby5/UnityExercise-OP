using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    // Exercise 3: Main player / game object that will move at constant speed, moving to 3 points in order 1,2,3.
    // This object will be removed when touching asteriods or upon reaching the 3rd and final point.
    [Header("Player Movement")]
    [SerializeField] private List<Transform> pointsToMoveTo; // In this case we will set 3 points to move to in order in the inspector, directly as transforms that can be freely moved and directly visualised. (2)
                                                             // Alternativly we can change to private List<float> pointsToMoveTo to input points manually in the inspector if preferred by designers.

    [SerializeField] private float speed = 5.0f; // (2)

    private int currentPointIndex = 0;

    private AudioSource audioSource;
    [Header("Game Over Effects")]
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private ParticleSystem particle;

    private void Awake()
    {
        audioSource = GetComponentInChildren<AudioSource>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // Move the object towards the current point at a constant speed (2)
        
        // If the object reaches the current point, move to the next point (3)

    }

    private void GameOverHandle()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        // If the object collides with an asteroid, destroy the object (4)

        // If the object reaches the final point, destroy the object (4)
    }

    private void OnDestroy()
    {
        // Call the restart or end game event (end screen / option to restart)
    }
}
