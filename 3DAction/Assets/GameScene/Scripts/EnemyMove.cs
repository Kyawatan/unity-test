using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(NavMeshAgent))]

public class EnemyMove : MonoBehaviour
{
    //private NavMeshAgent m_agent;
    [SerializeField] private float m_moveSpeed = 1f;
    private Transform m_transform;

    void Start()
    {
        //m_agent = GetComponent<NavMeshAgent>();
        m_transform = transform;
    }

    void Update()
    {
        //プレイヤーを目指して進む
        //m_agent.destination = m_playerController.transform.position;
    }

    public void MoveToPlayer(Transform playerTr) {
        // プレイヤーのいる位置へ回転
        m_transform.LookAt(playerTr);

        // プレイヤーのいる位置へ前進
        m_transform.position = m_transform.TransformPoint(new Vector3(0f, 0f, m_moveSpeed * Time.deltaTime));
    }
}
