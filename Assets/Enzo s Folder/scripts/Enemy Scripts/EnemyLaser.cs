using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float speed = 3f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        Destroy(gameObject, 1.5f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the HealthManager component from the player
            HealthManager healthManager = other.GetComponent<HealthManager>();

            if (healthManager != null)
            {
                // Call the TakeDamage method to reduce health
                healthManager.TakeDamage();
            }
            
            
            //Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
