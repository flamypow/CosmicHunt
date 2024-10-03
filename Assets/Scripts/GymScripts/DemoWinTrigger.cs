using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoWinTrigger : MonoBehaviour
{
    // THIS IS A DEMO SCRIPT TO SHOW HOW TO CALL THE WIN SCRIPT. THIS SCRIPT IS NOT REQUIRED.
    // I don't have the boss on hand so this demo script is written using points as a win factor. 

    // TL;DR: Run SceneManager.LoadScene("WinScreen"); to load the WinScreen

    // The number of points needed to win (for testing)
    [SerializeField] private int pointsToWin = 10;

    void Update()
    {
        // Check if the player has collected enough points
        if (GameManager.playerPoints >= pointsToWin)
        {
            // Trigger the win by loading the win screen scene
            TriggerWin();
        }
    }

    // Method to load the win screen
    void TriggerWin()
    {
        Debug.Log("You win! Loading win screen...");
        SceneManager.LoadScene("WinScreen");
    }
}
