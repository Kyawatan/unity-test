using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObjectScript : MonoBehaviour
{
    private Transform m_sphereTr;
    private Vector3 m_targetLocalPos;
    private Vector3 m_targetLocalRot;
    private bool m_isFollowable = false;

    public void OnIsFollowable(Transform targetTr)
    {
        if (m_isFollowable) return;

        // 衝突時の球から見た物体の座標を保持しておく
        m_sphereTr = DirectorScript.GetInstance.GetSphereTr;
        m_targetLocalPos = m_sphereTr.InverseTransformPoint(targetTr.position);
        m_isFollowable = true;
    }

    void Update()
    {
        if (!m_isFollowable) return;

        m_sphereTr = DirectorScript.GetInstance.GetSphereTr;

        //transform.position = m_sphereTr.position + m_targetLocalPos;
        //transform.position = m_sphereTr.InverseTransformPoint(m_sphereTr.position + m_targetLocalPos);

        // 物体のローカル座標をワールド座標に変換
        transform.position = m_sphereTr.TransformPoint(m_targetLocalPos);
        transform.rotation = DirectorScript.GetInstance.GetRotateDirection * transform.rotation;
    }
}
