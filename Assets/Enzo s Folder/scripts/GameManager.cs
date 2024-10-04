using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;

    private int enemiesDestroyed = 0;
    public int spawnIncreaseOne = 2;
    public int spawnIncreaseTwo = 6;
    public int EnemiesRequiredBoss = 10;
    public GameObject enemyPrefab;
    public GameObject bossPrefab;
    public Transform[] enemySpawnPoints;
    public Transform bossSpawnPoint;
    public float enemySpawnInterval = 2f;
    private int currentEnemyCount = 0;
    private bool bossSpawned = false;

    public static int playerPoints = 0;
    public int pointsForBossDefeat = 1000;

    // Flag to stop game logic when play dies
    private bool gameIsActive = true;

    // Points awarded for killing an enemy
    public int pointsPerEnemy = 100;

    // Reference to PointsManager to update points
    [SerializeField] private PointsManager pointsManager;

    // Name of the win screen scene
    [SerializeField] private string winScreenSceneName = "WinScreen";

    // Delay before loading the win screen after the player wins
    [SerializeField] private float winScreenDelay = 3f;

    void Awake() //singleton to make the manager "accessible"
    {
        if(Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
            Debug.Log("GameManager initialized");

            // Load points when the scene starts or game resets
            ResetGame();
        }
        else
        {
            Debug.Log("Duplicate GameManager Detected");
            Destroy(gameObject);
        }
    }

    // Call this method when the player wins the game
    public void PlayerWins()
    {
        // Stop game logic, sotp music
        StopGame();
        if (SoundManager.instance != null)
        {
            SoundManager.instance.StopMusic();
        }

        // Store the points so they can persist across scenes
        PlayerPrefs.SetInt("StoredPoints", playerPoints);
        PlayerPrefs.Save();

        // Load the win screen
        SceneManager.LoadScene(winScreenSceneName);
        
    }

    // Call this method when the game scene starts to reset or carry over points
    public void ResetGame()
    {
        // Check if stored points exist and load them, or reset to 0
        if (PlayerPrefs.HasKey("StoredPoints"))
        {
            playerPoints = PlayerPrefs.GetInt("StoredPoints");
        }
        else
        {
            playerPoints = 0; // Start fresh if no points are stored
        }

        PlayerPrefs.DeleteAll();
    }

    void Start()//keep spawning enemies
    {
       // Call ResetGame() when the scene starts
       ResetGame();
        
        InvokeRepeating(nameof(SpawnEnemy), 0f, enemySpawnInterval);
        SoundManager.instance.PlayMusic(0);
        
    }
    void SpawnEnemy()
    {
        if (!gameIsActive || bossSpawned) return;

        //if (bossSpawned) return;//stop spawning if boss is there
        if(currentEnemyCount < 1)
        {
            int enemiesSpawn = 1;
            if (enemiesDestroyed >= spawnIncreaseTwo)
            {
                enemiesSpawn = 3;
            }
            else if (enemiesDestroyed >= spawnIncreaseOne)
            {
                enemiesSpawn = 2;
            }
            List<Transform> FreeSpawns = new List<Transform>(enemySpawnPoints);

            for (int i = 0; i < enemiesSpawn && FreeSpawns.Count > 0; i++)
            {
                int randomList = Random.Range(0,FreeSpawns.Count);
                Transform spawnPoint = FreeSpawns[randomList];
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                currentEnemyCount++;
                FreeSpawns.RemoveAt(randomList);
            }
            
        }

    }
    public void EnemyDestroyed()//when base enemy dies
    {
        if (!gameIsActive) return; // Prevent further logic if game is no longer active

        enemiesDestroyed++;
        currentEnemyCount--;

        // Add points for killing an enemy using PointsManager
        if (pointsManager != null)
        {
            pointsManager.AddPoints(pointsPerEnemy);
        }

        if(enemiesDestroyed>=EnemiesRequiredBoss && !bossSpawned)
        {
            SummonBoss();
        }
    }
    void SummonBoss() //summon boss
    {
        if(bossPrefab != null && bossSpawnPoint != null)
        {
            Instantiate(bossPrefab, bossSpawnPoint.position, bossSpawnPoint.rotation);
            bossSpawned = true;
            SoundManager.instance.PlayMusic(1);
        }
    }

    public void BossDefeated()
    {
        if (pointsManager != null)
        {
            pointsManager.AddPoints(pointsForBossDefeat);
        }

        Debug.Log("Boss defeated! Points awarded: " + pointsForBossDefeat);
    }

    // Call this method when the player dies or the game should stop
    public void StopGame()
    {
        gameIsActive = false; // Stops further game logic like enemy spawning
        CancelInvoke(nameof(SpawnEnemy)); // Stop the repeating spawn function
    }
}
