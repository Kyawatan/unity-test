using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetecter : MonoBehaviour
{
    [SerializeField] private MobAttack m_attack;

    private void OnTriggerEnter(Collider other)
    {
        // 攻撃対象に攻撃が当たった
        m_attack.OnHitAttack(other);
    }
}
