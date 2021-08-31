using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float OFFSET_Z = -2f; // プレイヤーの後方
    private const float OFFSET_Y = 1f; // プレイヤーの上方
    private Transform m_transform;
    private Vector3 m_offset = new Vector3(0f, OFFSET_Y, OFFSET_Z);

    void Start()
    {
        m_transform = transform;
    }

    void Update()
    {
        
    }

    public void CameraPosition(Transform playerTr)
    {
        // プレイヤーと同じ方向に回転
        m_transform.eulerAngles = new Vector3(0f, playerTr.eulerAngles.y, 0f);

        // プレイヤーの後方に移動
        //m_transform.position = new Vector3(playerTr.position.x, playerTr.position.y + OFFSET_Y, playerTr.position.z + OFFSET_Z);
        m_transform.position = playerTr.TransformPoint(m_offset);
    }
}
