using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    [SerializeField] private GameObject playerBody;

    bool isGameOver = false;
    public UnityEvent gameOverEvent; // may be a bit much for this example, but is useful for other objects / scripts to listen for.

    private void Awake()
    {
        audioSource = GetComponentInChildren<AudioSource>();
    }

    private void Start()
    {
        if (gameOverEvent == null)
            gameOverEvent = new UnityEvent();
        gameOverEvent.AddListener(GameOverHandle);
    }

    private void Update()
    {
        if (isGameOver)
            return;
        // I was planning this to be in fixedupdate originally / may change movement force to rigidbody due to the line "Note that the game uses the physics system provided by Unity"
        // Keeping it simple for now for the first prototype.
        if (currentPointIndex < pointsToMoveTo.Count)
        {
            // Move the object towards the current point at a constant speed (2)
            transform.position = Vector3.MoveTowards(transform.position, pointsToMoveTo[currentPointIndex].position, speed * Time.deltaTime);
            // If the object reaches the current point, move to the next point (3)
            if (transform.position == pointsToMoveTo[currentPointIndex].position)
            {
                currentPointIndex++;
                Debug.Log("Current Point Index: " + currentPointIndex);
            }
        }   
        else 
        {
            gameOverEvent.Invoke();
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void GameOverHandle()
    {
        Debug.Log("Game Over");
        isGameOver = true;
        audioSource.PlayOneShot(gameOverSound);
        particle.Play();
        Destroy(playerBody);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);
        // If the object collides with an asteroid, destroy the object (4)
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            gameOverEvent.Invoke();
        }
    }
}
