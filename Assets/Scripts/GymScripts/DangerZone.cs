using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    // Reference to the HealthManager;
    private HealthManager healthManager;

    void Start()
    {
      // Find the HealthManager in the scene (ensure it's in the scene)
      healthManager = FindObjectOfType<HealthManager>();
    }

    // This will be called when something enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player entered the trigger
        if (other.CompareTag("Player"))
        {
            // Call the TakeDamage method to remove one heart
            healthManager.TakeDamage();
        }
    }
}
