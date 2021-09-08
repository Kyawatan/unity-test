using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed = 1f;
    [SerializeField] private float m_rotateSpeed = 360f;
    [SerializeField] private float m_dotRange = 0.707f; // 視野
    [SerializeField] private float m_distRange = 7f;    // 見える距離
    private Transform m_transform;
    private Transform m_playerTr;
    private Animator m_animator;
    private Vector3 m_toPlayerVec; // 敵からプレイヤーの方向ベクトル

    //void Start()
    //{
    //    m_transform = transform;
    //    m_animator = GetComponent<Animator>();
    //}

    //void Update()
    //{
    //    // プレイヤーの位置情報を取得
    //    m_playerTr = GameDirector.GetInstance().GetPlayerTr;
    //    m_toPlayerVec = m_playerTr.position - m_transform.position;

    //    // プレイヤーが視界に入れば追いかける
    //    bool isLook = IsLook();

    //    if (isLook)
    //    {
    //        MoveToPlayer();
    //    }

    //    // 歩行アニメーション
    //    m_animator.SetBool("isMove", isLook);
    //}

    //private bool IsLook()
    //{
    //    // 敵の進行方向ベクトルと、敵から見たプレイヤーの方向ベクトルで内積をとる
    //    float dot = Vector3.Dot(m_transform.forward, m_toPlayerVec.normalized);

    //    // プレイヤーと敵の距離
    //    float dist = m_toPlayerVec.magnitude;

    //    if (dot >= m_dotRange && dist <= m_distRange) return true;
    //    else return false;
    //}

    //private void MoveToPlayer()
    //{
    //    // プレイヤーのいる方向へ滑らかに回転
    //    Vector3 angle = new Vector3(m_toPlayerVec.x, 0f, m_toPlayerVec.z);
    //    Quaternion rot = Quaternion.LookRotation(angle, Vector3.up);
    //    m_transform.rotation = Quaternion.RotateTowards(m_transform.rotation, rot, m_rotateSpeed * Time.deltaTime);

    //    // プレイヤーのいる位置へ前進
    //    m_transform.position = m_transform.TransformPoint(new Vector3(0f, 0f, m_moveSpeed * Time.deltaTime));
    //}
}
