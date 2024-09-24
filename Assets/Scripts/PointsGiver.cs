using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsGiver : MonoBehaviour
{
    // Points awarded when this object is interacted with
    [SerializeField] private int pointsValue = 10;

    // Reference to the PointsManager
    private PointsManager pointsManager;

    void Start()
    {
        // Find the PointsManager in the scene
        pointsManager = FindObjectOfType<PointsManager>();
    }

    // Detect collision with the player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Give points to the player
            pointsManager.AddPoints(pointsValue);
            // Destroy the object after giving points 
            Destroy(gameObject);
        }
    }
}
