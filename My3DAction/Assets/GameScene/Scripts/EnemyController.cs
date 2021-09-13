using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private MobStatus m_status;
    [SerializeField] private Collider m_carrotCollider;
    [SerializeField] private float m_moveSpeed = 1f;
    [SerializeField] private float m_rotateSpeed = 360f;
    [SerializeField] private float m_dotRange = 0.707f; // 視野
    [SerializeField] private float m_distRange = 7f;    // 見える距離

    private Transform m_transform;
    private Transform m_playerTr;
    private GameObject m_targetCarrot;
    private Vector3 m_startVec;
    private Vector3 m_targetVec;
    private Vector3 m_targetCarrotVec;  // 目標のニンジンの座標
    private Vector3 m_toTargetCarrotVec; // 敵からニンジンの方向ベクトル
    private Vector3 m_toPlayerVec;      // 敵からプレイヤーの方向ベクトル
    private ENEMY_MODE m_mode = ENEMY_MODE.AimCarrot;

    private enum ENEMY_MODE
    {
        AimPlayer,      // プレイヤーを狙う
        AimCarrot,      // ニンジンを狙う
        rakeCarrot,     // ニンジンを盗む
        Escape          // 逃げる
    }

    void Start()
    {
        m_transform = transform;
        m_startVec = m_transform.position;

        // 目標のニンジンを取得
        m_targetCarrot = GameDirector.GetInstance.GetSetCarrotInfo;
    }

    void Update()
    {
        if (!m_status.IsNomalState)
        {
            m_animator.SetBool("isMove", false);
            return;
        }

        m_animator.SetBool("isMove", true);

        // プレイヤーの位置情報を取得
        m_playerTr = GameDirector.GetInstance.GetPlayerTr;
        m_toPlayerVec = m_playerTr.position - m_transform.position;

        // ターゲットを決定する
        if (IsLook() || m_targetCarrot == null)
        {
            // プレイヤーが視界に入るかニンジンが存在しない場合はプレイヤーの方を向く
            LookToTarget(m_toPlayerVec);
            if (m_carrotCollider.enabled) m_carrotCollider.enabled = false;
        }
        else
        {
            // ニンジンの方を向く
            m_targetCarrotVec = m_targetCarrot.transform.position;
            m_toTargetCarrotVec = m_targetCarrotVec - m_transform.position;

            LookToTarget(m_toTargetCarrotVec);
            if (m_toTargetCarrotVec.magnitude > 0.2 && !m_carrotCollider.enabled) m_carrotCollider.enabled = true;
        }

        // 前進
        m_transform.position = m_transform.TransformPoint(new Vector3(0f, 0f, m_moveSpeed * Time.deltaTime));
    }

    private bool IsLook()
    {
        // 敵の進行方向ベクトルと、敵から見たプレイヤーの方向ベクトルで内積をとる
        float dot = Vector3.Dot(m_transform.forward, m_toPlayerVec.normalized);

        // プレイヤーと敵の距離
        float dist = m_toPlayerVec.magnitude;

        if (dot >= m_dotRange && dist <= m_distRange) return true;
        else return false;
    }

    private void LookToTarget(Vector3 toTargetVec)
    {
        // ターゲットの方向へ回転
        Vector3 angle = new Vector3(toTargetVec.x, 0f, toTargetVec.z);
        Quaternion rot = Quaternion.LookRotation(angle, Vector3.up);
        m_transform.rotation = Quaternion.RotateTowards(m_transform.rotation, rot, m_rotateSpeed * Time.deltaTime);
    }
}
