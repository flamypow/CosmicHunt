using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Awake() //singleton to make the manager "accessible"
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()//keep spawning enemies
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, enemySpawnInterval);
    }
    void SpawnEnemy()
    {
        if (bossSpawned) return;//stop spawning if boss is there
        if(currentEnemyCount < 1)
        {
            int enemiesSpawn = 1;
            if (enemiesDestroyed >= spawnIncreaseOne)
            {
                enemiesSpawn = 2;
            }
            else if (enemiesDestroyed >= spawnIncreaseTwo)
            {
                enemiesSpawn = 3;
            }
            for (int i = 0; i< enemiesSpawn; i++)
            {
                int randomList = Random.Range(0,enemySpawnPoints.Length);
                Transform spawnPoint = enemySpawnPoints[randomList];
                Instantiate (enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                currentEnemyCount++;
            }
        }

    }
    public void EnemyDestroyed()//when base enemy dies
    {
        enemiesDestroyed++;
        currentEnemyCount--;
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
        }
    }
}
