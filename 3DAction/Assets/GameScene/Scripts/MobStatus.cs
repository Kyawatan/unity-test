using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MobStatus : MonoBehaviour
{
    [SerializeField] private float m_lifeMax = 10f;
    protected Animator m_animator;
    protected StateEnum m_state = StateEnum.Normal;
    private float m_life;

    // 状態の定義
    protected enum StateEnum
    {
        Normal,     // 通常
        Attack,     // 攻撃中
        Die         // 死亡
    }

    protected virtual void Start()
    {
        m_life = m_lifeMax;
        m_animator = GetComponentInChildren<Animator>();
    }

    protected virtual void OnDie()
    {
        // キャラクターが倒れた時の処理
    }

    /// <summary>
    /// キャラクターが規定値のダメージを受ける
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        if (m_state == StateEnum.Die)
        {
            m_life -= damage;
            if (m_life > 0) return;

            m_state = StateEnum.Die;
            m_animator.SetTrigger("Die");

            OnDie();
        }
    }

    // 可能であれば攻撃中Attackの状態に遷移する
    public void GoToAttackStateIfPossible()
    {
        if (!IsAttackable) return;

        m_state = StateEnum.Attack;
        m_animator.SetTrigger("Attack");
    }

    // 可能であれば通常Normalの状態に遷移する
    public void GoToNormalStateIfPossible()
    {
        if (m_state == StateEnum.Die) return;

        m_state = StateEnum.Normal;
    }

    // 移動可能かどうか
    public bool isMoveable => StateEnum.Normal == m_state;

    // 攻撃可能かどうか
    public bool IsAttackable => StateEnum.Attack == m_state;

    // ライフ最大値を返す
    public float LifeMax => m_lifeMax;
}
