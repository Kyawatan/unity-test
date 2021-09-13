using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCarrotDetector : MonoBehaviour
{
    [SerializeField] private float m_stayTime = 3f;
    [SerializeField] private EnemyController m_enemyController;

    private float m_nowStayTime = 0f;

    private void OnTriggerStay(Collider other)
    {
            m_nowStayTime += Time.deltaTime;

        if (m_nowStayTime >= m_stayTime)
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        m_nowStayTime = 0f;
    }
}
