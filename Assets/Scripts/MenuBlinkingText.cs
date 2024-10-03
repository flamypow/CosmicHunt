using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBlinkingText : MonoBehaviour
{
    // Reference to the TextMeshPro objects for each word
    [SerializeField] private TextMeshProUGUI cosmicText;
    [SerializeField] private TextMeshProUGUI huntText;
    [SerializeField] private TextMeshProUGUI pressAnyText;
    [SerializeField] private TextMeshProUGUI buttonText;

    // Time each word stays on/off before switching
    [SerializeField] private float blinkDuration = 0.5f;

    // The scene to load when a button is pressed
    [SerializeField] private string gameSceneName;

    void Start()
    {
        // Ensures all text starts off hidden
        cosmicText.gameObject.SetActive(false);
        huntText.gameObject.SetActive(false);
        pressAnyText.gameObject.SetActive(false);
        buttonText.gameObject.SetActive(false);
        
        // Start the blinking sequence
        StartCoroutine(BlinkTextSequence());
    }

    void Update()
    {
        // Check for any key/button press
        if (Input.anyKeyDown)
        {
            // Load the specified scene
            LoadGameScene();
        }
    }

    // Coroutine to blink each word in sequence
    private IEnumerator BlinkTextSequence()
    {
        while (true) // Infinite loop to keep the text blinking
        {
            // Bink "Cosmic"
            cosmicText.gameObject.SetActive(true);
            yield return new WaitForSeconds(blinkDuration);
            cosmicText.gameObject.SetActive(false);

            // Blink "Hunt"
            huntText.gameObject.SetActive(true);
            yield return new WaitForSeconds(blinkDuration);
            huntText.gameObject.SetActive(false);

            // Blink "Press Any"
            pressAnyText.gameObject.SetActive(true);
            yield return new WaitForSeconds(blinkDuration);
            pressAnyText.gameObject.SetActive(false);

            // Blink "Button"
            buttonText.gameObject.SetActive(true);
            yield return new WaitForSeconds(blinkDuration);
            buttonText.gameObject.SetActive(false);
        }
    }

    // Load the game scene when a button is pressed
    private void LoadGameScene()
    {
        if (!string.IsNullOrEmpty(gameSceneName))
        {
            Debug.Log("Loading game scene: " + gameSceneName);
            SceneManager.LoadScene(gameSceneName);
        }
        else
        {
            Debug.LogWarning("No game scene specified in the Inspector.");
        }
    }
}
