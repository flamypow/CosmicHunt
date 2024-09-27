using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMain : MonoBehaviour
{
    public BossParts part1;
    public BossParts part2;
    private int partsDestroyed = 0;
    public float moveSpeed = 0.1f;
    public float moveRange = 0.1f;
    private Vector3 startPosition;
    private bool isMoving = true;


    void Start()
    {
        part1.boss = gameObject;
        part2.boss = gameObject;
        
    }
    void Update()
    {
        if (isMoving)
        {
            MoveBoss();
        }
       
    }
    public void PartDestroyed()
    {
        partsDestroyed++;
        if (partsDestroyed >= 2)
        {

            BossDeath();
        }
    }

    void MoveBoss()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
    
    void BossDeath()
    {
        isMoving = false;
        StartCoroutine(DestroyBossAfter(3f));
        Debug.Log("boss killed"); //test
    }

    IEnumerator DestroyBossAfter(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
