using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public float moveRange = 0.1f;
    public GameObject laserPrefab;
    public Transform laserSpawnPointRight;
    public float shootInterval = 1f;
    public Transform laserSpawnPointLeft;
    private bool PlayerToTheLeft = true;
    private GameObject PlayerObject;
  
    private Vector3 startPosition;
    private float shootTimer;
    
    

    void Start()
    {
        PlayerObject = GameObject.Find("PlayerShip");
        shootTimer = shootInterval;
        startPosition = transform.position;
       
    }

    void Update()
    {
        MoveEnemy();
        ShootPlayer();
        if (PlayerObject.transform.position.x > gameObject.transform.position.x)
        {
            PlayerToTheLeft = false;
        }
        else
        {
            PlayerToTheLeft = true;
        }
    }

    void MoveEnemy()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void ShootPlayer()
    {
        shootTimer -= Time.deltaTime;
        if(shootTimer <= 0)
        {
            
            if (PlayerToTheLeft)
            {
                Instantiate(laserPrefab, laserSpawnPointLeft.position, laserSpawnPointLeft.rotation);
            }
            else
            {
                GameObject newLaser = Instantiate(laserPrefab, laserSpawnPointRight.position, laserSpawnPointRight.rotation);
                newLaser.GetComponent<EnemyLaser>().speed *= -1;
            }
            
            shootTimer = shootInterval;
            SoundManager.instance.PlaySound(1);
        }
    }

    

    void OnDestroy() //register the death of base enemies
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance.EnemyDestroyed();
        }
    }
}
