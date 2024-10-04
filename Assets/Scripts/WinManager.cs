using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    // Reference to the TextMeshPro object for displaying the points
    [SerializeField] private TextMeshProUGUI pointsText;

    // Allows you to set the delay before restarting the game in the editor
    [SerializeField] private float restartGameDelay = 3f;

    void Start()
    {
        // Display the player's points
        pointsText.text = GameManager.playerPoints.ToString();

        // Start the coroutine to return the game after a delay
        StartCoroutine(RestartGameAfterDelay());
    }

    private IEnumerator RestartGameAfterDelay()
    {
        yield return new WaitForSeconds(restartGameDelay);

        // Reload the game scene, but keep the player's points
        SceneManager.LoadScene("EnzoScene");
    }
}
