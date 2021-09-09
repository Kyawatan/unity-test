using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobStatus : MonoBehaviour
{
    protected Animator m_animator;
    protected MOB_STATE m_state;    

    public enum MOB_STATE
    {
        Normal,     // 通常
        Attack,     // 攻撃中
        Damage,     // ダメージ
        Die         // 死亡
    }

    public MOB_STATE GetNowState
    {
        get { return m_state; }
    }

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    public void GoToNormalState()
    {
        m_state = MOB_STATE.Normal;
    }

    public void GoToAttackState()
    {
        m_state = MOB_STATE.Attack;
        m_animator.SetTrigger("Attack");
    }

    public void Damage()
    {
        m_animator.SetTrigger("Damage");
    }
}
