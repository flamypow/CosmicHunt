using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    // Serialized fields for the three health images
    [SerializeField] private Image[] healthImages;

    // Number of hits the player can take (3)
    private int currentHealth;

    // Reference to the player GameObject
    [SerializeField] private GameObject player;

    // Time to wait before restarting the level (in seconds)
    [SerializeField] private float restartDelay = 2f;

    void Start()
    {
        // Initialize full health (3 hearts)
        currentHealth = healthImages.Length;
        UpdateHealthDisplay();
    }

    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--; // Reduce the health by 1
            UpdateHealthDisplay();

            if (currentHealth == 0)
            {
                // Player dies when health reaches 0
                Debug.Log("Player is dead");
                PlayerDeath();
            }
        }
    }

    void UpdateHealthDisplay()
    {
        // Loop through the health images and disable the ones that correspond to lost health
        for (int i = 0; i < healthImages.Length; i++)
        {
            if (i < currentHealth)
            {
                healthImages[i].enabled = true; // Show health image
            }
            else
            {
                healthImages[i].enabled = false; // Hide health image
            }
        }
    }

    // Player death logic
    void PlayerDeath()
    {
        // Hide the player object
        player.SetActive(false);

        // Restart the level after a delay
        Invoke("RestartLevel", restartDelay);
    }

    // Method to restart the level
    void RestartLevel()
    {
        // Reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
