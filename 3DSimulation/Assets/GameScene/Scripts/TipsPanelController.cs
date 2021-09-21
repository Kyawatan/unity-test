using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsPanelController : MonoBehaviour
{
    [SerializeField] private float m_enableTime = 10f;

    private float m_time = 0f;

    public void Awake()
    {
        gameObject.SetActive(false);
    }

    public void OnEnable()
    {
        m_time = 0f;
    }

    void Update()
    {
        m_time += Time.deltaTime;
        if (m_time >= m_enableTime) gameObject.SetActive(false);
    }
}
