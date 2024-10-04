using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    // Delay before returning the player to the main menu
    [SerializeField] private float returnToMenuDelay = 3f;

    // Name of the death scene to load
    [SerializeField] private string deathSceneName = "DeathScreen";

    private bool isDead = false;

    void Awake()
    {
        // Prevent the DeathManager from being destroyed when the scene changes
        DontDestroyOnLoad(gameObject);
    }

    // Call this method when the player dies
    public void HandlePlayerDeath()
    {
        if (!isDead)
        {
            isDead = true;

            // Stop all game logic
            if (GameManager.Instance != null)
            {
                GameManager.Instance.StopGame(); // Stops enemy spawning and all other game logic 
            }

            // Stop the music
            if (SoundManager.instance != null)
            {
                SoundManager.instance.StopMusic();
            }

            // Load the death screen
            SceneManager.LoadScene(deathSceneName);

            // Start the coroutine to wait before returning to the main menu
            StartCoroutine(ReturnToMainMenuAfterDelay());
        }
    }

    // Coroutine to wait for the delay before loading the main menu
    private IEnumerator ReturnToMainMenuAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(returnToMenuDelay);

        // Load the main menu scene
        Debug.Log("Returning to the main menu...");
        SceneManager.LoadScene("MainMenu");
    }
}
