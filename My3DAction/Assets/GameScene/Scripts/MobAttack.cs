using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAttack : MonoBehaviour
{
    [SerializeField] private Collider m_attackCollider;


    public void OnAttackStart()
    {
        // 攻撃の開始時に呼ばれる
        m_attackCollider.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    public void OnAttackFinished()
    {
        // 攻撃の終了時に呼ばれる
        m_attackCollider.enabled = false;
    }
}
