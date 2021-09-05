using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAttack : MonoBehaviour
{
    [SerializeField] private float m_attackCooldown = 0.5f;
    [SerializeField] private Collider m_attackCollider;

    private MobStatus m_status;

    void Start()
    {
        m_status = GetComponent<MobStatus>();
    }

    public void AttackIfPossible()
    {
        // ステータスと衝突したオブジェクトで攻撃可否を判断
        if (!m_status.IsAttackable) return;

        // 攻撃可能な状態であれば攻撃を行う
        m_status.GoToAttackStateIfPossible();
    }

    /// <summary>
    /// 攻撃対象が攻撃範囲に入った時に呼ばれる
    /// </summary>
    /// <param name="collider"></param>
    public void OnAttackRangeEnter(Collider collider)
    {
        AttackIfPossible();
    }

    public void OnAttackStart()
    {
        // 攻撃の開始時に呼ばれる
        m_attackCollider.enabled = true;
    }

    /// <summary>
    /// attackColliderが攻撃対象にHitした時に呼ばれる
    /// </summary>
    /// <param name="collider"></param>
    public void OnHitAttack(Collider collider)
    {
        var targetMob = collider.GetComponent<MobStatus>();
        if (targetMob == null) return;
        targetMob.Damage(1);
    }

    public void OnAttackFinished()
    {
        // 攻撃の終了時に呼ばれる
        m_attackCollider.enabled = false;
        StartCoroutine(CooldownCoroutine());
    }

    private　IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(m_attackCooldown);
        m_status.GoToNormalStateIfPossible();
    }
}
