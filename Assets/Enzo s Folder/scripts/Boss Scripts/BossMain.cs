using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BossState
{
    Undamaged = 0,
    DamageLeft = 1,
    DamageRight = 2,
    Damaged = 3,
}
public class BossMain : MonoBehaviour
{
    public BossParts part1;
    public BossParts part2;
    private int partsDestroyed = 0;
    public float moveSpeed = 0.1f;
    public float moveRange = 0.1f;
    public BossState currentBossState;
    [SerializeField] BossSprite bossSprite;


    void Start()
    {
        part1.boss = gameObject;
        part2.boss = gameObject;
        currentBossState = BossState.Undamaged;
    }
    
    public void PartDestroyed(bool isRight)
    {
        partsDestroyed++;
        
        if (isRight)
        {
            if (currentBossState == BossState.Undamaged)
            {
                currentBossState = BossState.DamageRight;
                bossSprite.ChangeSprite(currentBossState);
            }
            else if (currentBossState == BossState.DamageRight)
            {
                Debug.Log("error: destroying same arm twice");
            }
            else if (currentBossState == BossState.DamageLeft)
            {
                currentBossState = BossState.Damaged;
            }
            else {

                Debug.Log("error: destroying same arm twice");
            }
                    
                
        }
        else
        {
            if (currentBossState == BossState.Undamaged)
            {
                currentBossState = BossState.DamageLeft;
                bossSprite.ChangeSprite(currentBossState);
            }
            else if (currentBossState == BossState.DamageRight)
            {
                currentBossState = BossState.Damaged;
            }
            else if (currentBossState == BossState.DamageLeft)
            {
                Debug.Log("error: destroying same arm twice");
            }
            else
            {

                Debug.Log("error: destroying same arm twice");
            }
        }







        if (partsDestroyed >= 2)
        {
            SoundManager.instance.StopMusic();
            BossDeath();
        }

    }

   
    void BossDeath()
    {
        
        StartCoroutine(DestroyBossAfter(3f));
        //Debug.Log("boss killed"); //test
    }

    IEnumerator DestroyBossAfter(float delay)
    {
        yield return new WaitForSeconds(delay);
        SoundManager.instance.PlaySound(6);
        Destroy(gameObject);
    }
}
