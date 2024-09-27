using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossParts : MonoBehaviour
{
    public int health = 5;
    public GameObject boss;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyPart();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
        if (other.gameObject.CompareTag("PlayerShot"))
        {
            GetComponent<BossParts>().TakeDamage(1);
            Destroy(other.gameObject);
        }
    }
    void DestroyPart()
    {
        gameObject.SetActive(false);
        boss.GetComponent<BossMain>().PartDestroyed();
    }
}
