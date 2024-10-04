using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    // Serialized fields for the health GameObjects (each containing the images for a life)
    [SerializeField] private GameObject[] healthGroups;

    // Number of hits the player can take (3)
    private int currentHealth;

    // Reference to the DeathManager to trigger the death scene
    [SerializeField] private DeathManager deathManager;

    void Start()
    {
        // Initialize full health (number of life)
        currentHealth = healthGroups.Length;
        UpdateHealthDisplay();
    }

    // Method to be called when the player takes damage
    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--; // Reduces the player's health
            UpdateHealthDisplay();

            // Check if health is zero and trigger death
            if (currentHealth == 0)
            {
                Debug.Log("Player is dead");
                PlayerDeath();
            }
        }
    }

    // Update the display of hearts/lives on the screeen
    void UpdateHealthDisplay()
    {
        // Loop through the health groups and toggle visibility based on current health
        for (int i = 0; i < healthGroups.Length; i++)
        {
            if (i < currentHealth)
            {
                healthGroups[i].SetActive(true); // Show the entire group of images for this life
            }
            else
            {
                healthGroups[i].SetActive(false); // Hide the entire group of images for this life
            }
        }
    }

    // Handle the player's death
    void PlayerDeath()
    {
        // Call the death manager to load the death screen / handle game over logic
        deathManager.HandlePlayerDeath();
    }
}
