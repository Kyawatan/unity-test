using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private Vector3 m_thisLocalPos; // 地球から見たオブジェクトの座標

    void Start()
    {
        // ゲームスタート時の地球から見たオブジェクトの座標を保持
        Transform earthTr = GameDirector.GetInstance.GetEarthTr;
        m_thisLocalPos = earthTr.InverseTransformPoint(transform.position);
    }

    void Update()
    {
        // 移動
        Transform earthTr = GameDirector.GetInstance.GetEarthTr;
        transform.position = earthTr.TransformPoint(m_thisLocalPos);

        // 回転
        Quaternion rot = GameDirector.GetInstance.GetRotationAngle;
        transform.rotation = rot * transform.rotation;
    }
}
