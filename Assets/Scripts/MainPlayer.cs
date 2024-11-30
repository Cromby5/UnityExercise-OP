using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    // Exercise 3: Main player / game object that will move at constant speed, moving to 3 points in order 1,2,3.
    // This object will be removed when touching asteriods or upon reaching the 3rd and final point.
    [Header("Player Movement")]
    private List<Transform> pointsToMoveTo; // In this case we will set 3 points to move to in order in the inspector, directly as transforms that can be freely moved and directly visualised. (2)
                                                             // Alternativly we can change to private List<float> pointsToMoveTo to input points manually in the inspector if preferred by designers.
                                                             // Our points should be grabbed from the level manager, to allow the player to be dropped in freely
    [SerializeField] private float speed = 5.0f; // (2)

    private int currentPointIndex = 0;

    private AudioSource audioSource;

    [Header("Player Win Effects")]
    [SerializeField] private AudioClip winSound;
    [SerializeField] private ParticleSystem winParticle;

    [Header("Player Lose Effects")]
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private ParticleSystem loseParticle;

    [Header("")]

    [SerializeField] private GameObject playerBody;

    bool isGameOver = false;
    bool isGameWon = false;

    [Header("TEST Functions")]
    [SerializeField] private bool hasCollision = false;

    private void Awake()
    {
        audioSource = GetComponentInChildren<AudioSource>();
    }

    private void Start()
    {
        LevelManager.instance.gameOverEvent.AddListener(GameOverHandle);
        LevelManager.instance.resetEvent.AddListener(Reset);
    }

    private void Update()
    {
        if (isGameOver) return;
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
            isGameWon = true; // changes the sound and particle effect to a win effect.
            LevelManager.instance.winEvent.Invoke();
            Debug.Log("You Win");
            LevelManager.instance.gameOverEvent.Invoke();
        }
    }
    private void GameOverHandle()
    {
        Debug.Log("Game Over");
        isGameOver = true;
        if (isGameWon)
        {
            audioSource.PlayOneShot(winSound);
            winParticle.Play();
        }
        else
        {
            audioSource.PlayOneShot(gameOverSound);
            loseParticle.Play();
        }
        //Destroy(playerBody);
        playerBody.SetActive(false); // changing to allow quick reset of the player object. 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasCollision) return; // For testing purposes, to avoid collisions and test path.

        Debug.Log("Collision with: " + collision.gameObject.name);
        // If the object collides with an asteroid, destroy the object (4)
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            LevelManager.instance.gameOverEvent.Invoke();
        }
    }

    public void SetPointsToMoveTo(List<Transform> points)
    {
        pointsToMoveTo = points;
    }

    private void Reset() // Testing purposes, to reset the player object quickly. better than restarting / building the game each time (slow process). 
    {
        currentPointIndex = 0;
        audioSource.Stop();

        winParticle.gameObject.SetActive(false); // particle stop does not really do what I want, this is a workaround.
        winParticle.gameObject.SetActive(true);
        loseParticle.gameObject.SetActive(false);
        loseParticle.gameObject.SetActive(true);

        isGameOver = false;
        isGameWon = false;
        transform.position = Vector3.zero; // Use the players start point. requested to be 0,0,0 for now so this is fine.
        playerBody.SetActive(true);
    }
}
