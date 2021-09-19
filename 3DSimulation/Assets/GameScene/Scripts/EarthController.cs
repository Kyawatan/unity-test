using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController : MonoBehaviour
{
    [SerializeField] private float m_axisTilt = 23.4f; // 軸の傾き
    [SerializeField] private bool m_isAutoRot = false;
    [SerializeField] private float m_SelfrotationSpeed = 30f; // 自転速度（手動）
    [SerializeField] private float m_AutorotationSpeed = 10f; // 自転速度（自動）

    private Quaternion m_rot;

    public bool GetSetIsAutoRot
    {
        get { return m_isAutoRot; }
        set { m_isAutoRot = !m_isAutoRot; }
    }

    public Transform GetEarthTr
    {
        get { return transform; }
    }

    private void Update()
    {
        // 自転
        if (GetSetIsAutoRot)
        {
            m_rot = Quaternion.AngleAxis(m_AutorotationSpeed * Time.deltaTime, transform.up);
        }
        else
        {
            Vector3 inputVec = new Vector3(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), 0f).normalized;
            m_rot = Quaternion.AngleAxis(m_SelfrotationSpeed * Time.deltaTime, inputVec);
        }

        transform.rotation = m_rot * transform.rotation;
    }
}
