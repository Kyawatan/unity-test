using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobStatus : MonoBehaviour
{
    protected Animator m_animator;
    protected StateEnum m_status;    

    protected enum StateEnum
    {
        Normal,     // 通常
        Attack,     // 攻撃中
        Die         // 死亡
    }

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    public void GoToAttackState()
    {
        m_animator.SetTrigger("Attack");
    }

    public void Damage()
    {
        m_animator.SetTrigger("Damage");
    }
}
