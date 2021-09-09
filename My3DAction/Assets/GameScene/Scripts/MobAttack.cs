using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAttack : MonoBehaviour
{
    [SerializeField] private Collider m_attackCollider;
    [SerializeField] private int m_attackPower = 1; // 攻撃力
    [SerializeField] private float m_attackCooldown = 0.5f;
    [SerializeField] private float m_damageCooldown = 0.5f;

    private MobStatus m_status;

    private void Start()
    {
        m_status = GetComponent<MobStatus>();
    }

    public void OnAttackRangeEnter()
    {
        // 攻撃対象が攻撃範囲に入った時に呼ばれる
        if (m_status.IsNomalState) m_status.GoToAttackState();
    }

    public void OnAttackStart()
    {
        // 攻撃の開始時に呼ばれる
        m_attackCollider.enabled = true;
    }

    public void OnHitAttack(Collider collider)
    {
        // 攻撃対象に攻撃が当たった時に呼ばれる
        MobStatus target = collider.GetComponentInChildren<MobStatus>();
        target.Damage(m_attackPower);
    }

    public void OnAttackFinished()
    {
        // 攻撃の終了時に呼ばれる
        m_attackCollider.enabled = false;
        StartCoroutine(CooldownCoroutine(m_attackCooldown));
    }

    private void OnDamageFinished()
    {
        // ダメージの終了時に呼ばれる
        StartCoroutine(CooldownCoroutine(m_damageCooldown));
    }

    private IEnumerator CooldownCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        m_status.GoToNormalState();
    }
}
