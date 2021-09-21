using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestGenerator : MonoBehaviour
{
    [SerializeField] private GameObject m_chest;
    [SerializeField] private float m_intervalTime = 30f; // チェストの出現間隔（s）

    private float m_time = 0f;

    void Update()
    {
        if (m_chest.activeSelf) return;

        m_time += Time.deltaTime;

        if (m_time >= m_intervalTime)
        {
            m_chest.SetActive(true);
            m_time = 0f;
        }
    }
}
