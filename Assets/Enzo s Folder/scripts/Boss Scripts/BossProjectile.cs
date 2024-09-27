using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 direction;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    
}
