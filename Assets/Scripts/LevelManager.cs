using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    // Exercise 3
    public static LevelManager instance;

    [SerializeField] private List<Transform> pointsToMoveTo; // Set these with the inspector, to allow designers to freely move and visualise the points.
    [SerializeField] private Transform playerStart; // Where the player starts on the level

    public UnityEvent gameOverEvent; // may be a bit much for this example, but is useful for other objects / scripts to listen for.
    public UnityEvent winEvent;
    public UnityEvent resetEvent;

    [Header("UI")] // Normally I would use a manager to handle these elements to allow expansion, however I want to keep this simple and self contained 
    [SerializeField] private TextMeshProUGUI attemptsText;
    [SerializeField] private TextMeshProUGUI winsText;
    private int attempts = 0;
    private int wins = 0;

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

        //player.transform.position = playerStart.position;

        gameOverEvent ??= new UnityEvent();
        winEvent ??= new UnityEvent();
        resetEvent ??= new UnityEvent();
    }
    void Start()
    {
        gameOverEvent.AddListener(UpdateUI);
        resetEvent.AddListener(Reset);
        winEvent.AddListener(Win);

        attempts++;
        UpdateUI();
    }

    private void UpdateUI()
    { 
        Debug.Log("Update UI");
        attemptsText.text = "" + attempts;
        winsText.text = "" + wins;
    }

    private void Reset()
    {
        attempts++;
        UpdateUI();
    }

    private void Win()
    {
        wins++;
        UpdateUI();
    }

}
