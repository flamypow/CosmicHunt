using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    // Reference to the TextMeshPro object for displaying the points
    [SerializeField] private TextMeshProUGUI pointsText;

    // Allows you to set the delay before being returned to the main menu in the editor
    [SerializeField] private float returnToMenuDelay = 3f;

    void Start()
    {
        // Display the player's points
        pointsText.text = GameManager.playerPoints.ToString();

        // Start the coroutine to return to the main menu after a delay
        StartCoroutine(ReturnToMainMenuAfterDelay());
    }

    private IEnumerator ReturnToMainMenuAfterDelay()
    {
        yield return new WaitForSeconds(returnToMenuDelay);
        SceneManager.LoadScene("MainMenu");
    }
}
