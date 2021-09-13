using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAttack : MonoBehaviour
{
    [SerializeField] private Collider m_attackCollider;
    [SerializeField] private int m_attackPower = 1; // 攻撃力
    [SerializeField] private float m_attackCooldown = 0.5f;
    [SerializeField] private float m_damageCooldown = 0.5f;

    [SerializeField] private Transform m_playerLeftHandTr;

    private MobStatus m_status;
    private GameObject m_haveCarrot;

    private void Start()
    {
        m_status = GetComponent<MobStatus>();
    }

    public void OnAttackRangeEnter()
    {
        // 攻撃対象が攻撃範囲に入った時に呼ばれる
        if (m_status.IsNomalState && !GameDirector.GetInstance.IsFinishGame) m_status.GoToAttackState();
    }

    public void OnAttackStart()
    {
        // 攻撃の開始時に呼ばれる
        m_attackCollider.enabled = true;
    }

    public void OnHitAttack(Collider collider)
    {
        // 攻撃対象に攻撃が当たった時に呼ばれる
        m_status.OnParticle();
        MobStatus targetStatus = collider.GetComponentInChildren<MobStatus>();
        targetStatus.Damage(m_attackPower);
    }

    public void OnAttackFinished()
    {
        // 攻撃の終了時に呼ばれる
        m_attackCollider.enabled = false;
        StartCoroutine(CooldownCoroutine(m_attackCooldown));
    }

    public void OnTakeCarrot(Collider collider)
    {
        if (m_status.GetSetIsHavingCarrot) return; // 既にニンジンを持っていればreturn

        m_haveCarrot = collider.gameObject;
        Transform carrotTr = collider.GetComponent<Transform>();
        carrotTr.parent = m_playerLeftHandTr;
        carrotTr.localPosition = new Vector3(-0.1f, -0.09f, 0f);
        carrotTr.localEulerAngles = new Vector3(18.17f, -90f, 2f);
        carrotTr.localScale = new Vector3(3f, 3f, 2f);

        m_status.GetSetIsHavingCarrot = true;
    }

    public void OnDestroyCarrot(Collider collider)
    {
        if (!m_status.GetSetIsHavingCarrot) return; // ニンジンを持っていなければreturn

        collider.GetComponentInChildren<ParticleController>().OnHitParticle(); // 納品パーティクル再生
        GameDirector.GetInstance.RemoveCarrotList(m_haveCarrot);
        m_status.GetSetIsHavingCarrot = false;
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
