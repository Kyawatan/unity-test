using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAttack : MonoBehaviour
{
    [SerializeField] private Collider m_attackCollider;

    private MobStatus m_status;

    private void Start()
    {
        m_status = GetComponent<MobStatus>();
    }

    public void OnAttackRangeEnter()
    {
        // 攻撃対象が攻撃範囲に入ったら攻撃状態へ遷移する
        m_status.GoToAttackState();
    }

    public void OnAttackStart()
    {
        // 攻撃の開始時に呼ばれる
        m_attackCollider.enabled = true;
    }

    /// <summary>
    /// 攻撃対象に攻撃が当たったときに呼ばれる
    /// </summary>
    /// <param name="collider"></param>
    public void OnHitAttack(Collider collider)
    {
        // 攻撃対象にダメージを与える
        MobStatus target = collider.GetComponentInChildren<MobStatus>();
        target.Damage();
    }

    public void OnAttackFinished()
    {
        // 攻撃の終了時に呼ばれる
        m_attackCollider.enabled = false;
        m_status.GoToNormalState();
    }
}
