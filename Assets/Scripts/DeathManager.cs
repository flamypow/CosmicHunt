using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    // References to UI elements
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private TextMeshProUGUI deathText;
    [SerializeField] private GameObject pointsText;

    // Delay before returning the player to the main menu
    [SerializeField] private float returnToMenuDelay = 3f;

    private bool isDead = false;

    // Call this method when the player dies
    public void HandlePlayerDeath()
    {
        if (!isDead)
        {
            isDead = true;

            // Hides the points display
            pointsText.gameObject.SetActive(false);

            // Show the death screen and message
            deathScreen.SetActive(true);
            deathText.text = "Try Again";

            // Pauses the game
            Time.timeScale = 0f;

            // This handles the delay before the main menu is loaded
            StartCoroutine(ReturnToMainMenuAfterDelay());
        }
    }

    // Coroutine to wait for the delay, thne return to the main menu
    private IEnumerator ReturnToMainMenuAfterDelay()
    {
        // Wait for the delay, which also ignores the time scale
        yield return new WaitForSecondsRealtime(returnToMenuDelay);

        // Unpause the game
        Time.timeScale = 1f;

        // Load the main menu scene
        Debug.Log("Returning to the main menu...");
        SceneManager.LoadScene("MainMenu");
    }
}
