using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossSprites", menuName = "ScriptableObjects/BossSprites", order = 1)]
public class BossScriptableObject :ScriptableObject
{
    [SerializeField] public Sprite BossUndamaged;
    [SerializeField] public Sprite BossDamagedRight;
    [SerializeField] public Sprite BossDamagedLeft;
    [SerializeField] public Sprite BossDamaged;
}
