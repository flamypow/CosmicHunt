using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables to control speed
    public float moveSpeed = 5f;

    // Stores player movement input
    private Vector2 movement;

    void Update()
    {
        // Get input for horizontal and vertical movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Move the player based on input
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
