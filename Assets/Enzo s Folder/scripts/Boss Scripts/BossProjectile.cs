using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    //public float speed = 5f;
    //public Vector2 direction;
    public float timeUntilDestroyed = 2f;

    void Start()
    {
        Destroy(gameObject, timeUntilDestroyed);
    }

    void Update()
    {
        //transform.Translate(direction * speed * Time.deltaTime);
    }

    // Detect collision with the player
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the projectile his the player
        if (other.CompareTag("Player"))
        {
            // Get the HealthManager component from the player
            HealthManager healthManager = other.GetComponent<HealthManager>();

            if (healthManager != null)
            {
                // Call TakeDamage to reduce the player's health
                healthManager.TakeDamage();
                SoundManager.instance.PlaySound(2);
            }

            // Destroy the boss projectile after hitting the player
            Destroy(gameObject);
        }
    }
}
