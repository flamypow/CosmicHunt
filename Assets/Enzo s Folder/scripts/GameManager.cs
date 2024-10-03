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
        SoundManager.instance.PlayMusic(0);
    }
    void SpawnEnemy()
    {
        if (bossSpawned) return;//stop spawning if boss is there
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
            SoundManager.instance.PlayMusic(1);
        }
    }
}
