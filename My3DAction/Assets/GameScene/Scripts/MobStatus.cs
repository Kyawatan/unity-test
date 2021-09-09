using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobStatus : MonoBehaviour
{
    [SerializeField] protected int m_lifeMax = 3;

    protected Animator m_animator;
    protected MOB_STATE m_state;
    protected int m_life; // 現在のライフ数

    protected enum MOB_STATE
    {
        Normal,     // 通常
        Attack,     // 攻撃中
        Damage,     // ダメージ
        Die         // 死亡
    }

    public bool IsNomalState => m_state == MOB_STATE.Normal;

    protected virtual void Start()
    {
        m_animator = GetComponent<Animator>();
        m_life = m_lifeMax;
    }

    protected virtual void OnDie()
    {
        // キャラクターが倒れた時の処理
    }

    public void GoToNormalState()
    {
        if (m_state == MOB_STATE.Die) return;
        m_state = MOB_STATE.Normal;
    }

    public void GoToAttackState()
    {
        m_state = MOB_STATE.Attack;
        m_animator.SetTrigger("Attack");
    }

    public void GoToDamageState()
    {
        m_state = MOB_STATE.Damage;
        m_animator.SetTrigger("Damage");
    }

    public void GoToDieState()
    {
        m_state = MOB_STATE.Die;
        m_animator.SetTrigger("Die");
    }

    public void Damage(int damage)
    {
        m_life -= damage;

        if (m_life > 0)
        {
            GoToDamageState();
        }
        else
        {
            GoToDieState();
            OnDie();
        }
    }
}
