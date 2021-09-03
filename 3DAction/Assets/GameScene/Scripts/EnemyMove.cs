using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(NavMeshAgent))]

public class EnemyMove : MonoBehaviour
{
    //private NavMeshAgent m_agent;
    [SerializeField] private float m_moveSpeed = 1f;
    [SerializeField] private float m_rotateSpeed = 360f;
    [SerializeField] private float m_dotRange = 0.707f; // 視野
    [SerializeField] private float m_distRange = 7f;    // 見える距離
    private Transform m_transform;
    private Transform m_playerTr;
    private Vector3 m_toPlayerVec; // 敵からプレイヤーの方向ベクトル

    void Start()
    {
        //m_agent = GetComponent<NavMeshAgent>();
        m_transform = transform;
    }

    void Update()
    {
        //プレイヤーを目指して進む
        //m_agent.destination = m_playerController.transform.position;

        // プレイヤーの位置情報を取得
        m_playerTr = GameDirector.GetInstance().GetPlayerTr;
        m_toPlayerVec = m_playerTr.position - m_transform.position;

        // プレイヤーが視界に入れば追いかける
        if (IsLook())
        {
            MoveToPlayer();
        }
    }

    private bool IsLook()
    {
        // 敵の進行方向ベクトルと、敵から見たプレイヤーの方向ベクトルで内積をとる
        float dot = Vector3.Dot(m_transform.forward, m_toPlayerVec.normalized);
        
        //プレイヤーと敵の距離
        float dist = m_toPlayerVec.magnitude;

        if (dot >= m_dotRange && dist <= m_distRange) return true;
        else return false;      
    }

    private void MoveToPlayer() 
    {
        // プレイヤーのいる方向へ滑らかに回転
        //m_transform.LookAt(playerTr);
        Vector3 angle = new Vector3(m_toPlayerVec.x, 0f, m_toPlayerVec.z);
        Quaternion rot = Quaternion.LookRotation(angle, Vector3.up);
        m_transform.rotation = Quaternion.RotateTowards(m_transform.rotation, rot, m_rotateSpeed * Time.deltaTime);

        // プレイヤーのいる位置へ前進
        m_transform.position = m_transform.TransformPoint(new Vector3(0f, 0f, m_moveSpeed * Time.deltaTime));
    }
}
