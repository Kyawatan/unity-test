using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionRangeDetecter : MonoBehaviour
{
    [SerializeField] private MobAttack m_attack;

    private void OnTriggerStay(Collider other)
    {
        // 攻撃対象が攻撃範囲に入っている
        m_attack.OnAttackRangeEnter();
    }
}
