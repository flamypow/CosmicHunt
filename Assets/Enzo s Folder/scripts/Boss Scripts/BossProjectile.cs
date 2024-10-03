using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 direction;
    public float timeUntilDestroyed = 2f;

    void Start()
    {
        Destroy(gameObject, timeUntilDestroyed);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    
}
