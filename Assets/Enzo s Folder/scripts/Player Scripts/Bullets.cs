using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {

        transform.Translate(Vector3.right*speed*Time.deltaTime);
        Destroy(gameObject, 1f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            SoundManager.instance.PlaySound(4);
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
    }
}

