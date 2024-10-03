using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossParts : MonoBehaviour
{
    public int health = 5;
    public GameObject boss;
    public GameObject projectilePrefab;
    public Transform projectileSpawn;
    public float shootInterval = 2f;
    public float projectileSpeed = 5f;
    private float shootTimer;
    public GameObject player;
    public bool isRight;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            ShootRandomProjectiles();
            shootTimer = shootInterval;
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyPart(isRight);
        }
    }
    void OnTriggerEnter2D(Collider2D other) //reads damage from player bullet
    {
        Debug.Log("Hit");
        if (other.gameObject.CompareTag("PlayerShot"))
        {
            GetComponent<BossParts>().TakeDamage(1);
            Destroy(other.gameObject);
        }
    }
    void DestroyPart(bool isRight) //destroys the part
    {
        gameObject.SetActive(false);
        boss.GetComponent<BossMain>().PartDestroyed(isRight);
        SoundManager.instance.PlaySound(5);
    }

    void ShootRandomProjectiles() //pick between two types of projectiles for the boss
    {
        int randomShot = Random.Range(0, 2);

        if (randomShot == 0)
        {
            ShootConeSpread();
        }
        else
        {
            ShootStraightProjectile();
        }
    }

    void ShootConeSpread() // buckshot logic
    {
        int projectileNumber = 5;
        float spreadAngle = 60f;
        float startAngle = -spreadAngle / 2;
        float angleStep = spreadAngle / (projectileNumber - 1);

        for (int i = 0; i < projectileNumber; i++)
        {
            float angle = startAngle + (i * angleStep);
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawn.position, projectileSpawn.rotation * rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = projectile.transform.up * projectileSpeed;
            
        }
    }

    void ShootStraightProjectile() //basic shot logic
    {
        if(player != null)
        {
            //have the simple projectile aimed at the player
            Vector2 direction = (player.transform.position - projectileSpawn.position).normalized;
            //test calculate angle to the player
            float angle = Mathf.Atan2(direction.y, direction.x)* Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angle - 90);
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawn.position, rotation);
            Rigidbody2D rb = projectile.GetComponent <Rigidbody2D>();
            rb.velocity = direction * projectileSpeed;  
        }
    }
}
