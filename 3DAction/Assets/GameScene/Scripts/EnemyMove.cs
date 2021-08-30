using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private PlayerController m_playerController;
    private NavMeshAgent m_agent;

    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //プレイヤーを目指して進む
        m_agent.destination = m_playerController.transform.position;
    }
}
