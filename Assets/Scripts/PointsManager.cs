using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    // Serialized field for the TextMeshProUGUI component to display the score
    [SerializeField] private TextMeshProUGUI pointsText;

    // The player's score
    private int points = 0;

    void Start()
    {
      UpdatePointsText();
    }

    // Method to add points
    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
        GameManager.playerPoints =points;
        UpdatePointsText();
    }

    // Updates the points display on the screen
    private void UpdatePointsText()
    {
        pointsText.text = points.ToString();
    }
}
