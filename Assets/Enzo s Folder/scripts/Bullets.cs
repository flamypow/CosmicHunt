using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float speed = 10f;

    private void Update()
    {
        transform.Translate(Vector3.right*speed*Time.deltaTime);
        Destroy(gameObject, 1f);
    }
}
