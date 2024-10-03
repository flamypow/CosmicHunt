using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSprite : MonoBehaviour
{
    public SpriteRenderer bossShip;
    [SerializeField] private BossScriptableObject bossScriptObj;
    // Start is called before the first frame update
    void Start()
    {
        bossShip = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite(BossState bossState)
    { 
        if(bossState==BossState.Undamaged)
        {
            bossShip.sprite = bossScriptObj.BossUndamaged;
        
        }
        else if (bossState == BossState.DamageRight)
        {
            bossShip.sprite = bossScriptObj.BossDamagedRight;

        }
        else if (bossState == BossState.DamageLeft)
        {
            bossShip.sprite = bossScriptObj.BossDamagedLeft;

        }
        else if (bossState == BossState.Damaged)
        {
            bossShip.sprite = bossScriptObj.BossDamaged;

        }
    }

}
