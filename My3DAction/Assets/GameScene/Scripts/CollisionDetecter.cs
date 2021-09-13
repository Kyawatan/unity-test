using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetecter : MonoBehaviour
{
    [SerializeField] private MobAttack m_attack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            // 対象がニンジンの場合、ニンジンを左手に持つ
            m_attack.OnTakeCarrot(other);
        }
        else if (other.gameObject.layer == 14)
        {
            // 対象が収穫箱の場合、ニンジンを破棄する
            m_attack.OnDestroyCarrot(other);
        }
        else
        {
            // 攻撃対象に攻撃が当たった
            m_attack.OnHitAttack(other);
        }
    }
}
