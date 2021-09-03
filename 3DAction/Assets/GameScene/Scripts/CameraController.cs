using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float OFFSET_Z = -4.79f; // プレイヤーの後方
    private const float OFFSET_Y = 1.01f; // プレイヤーの上方
    private Transform m_transform;
    [SerializeField] private Vector3 m_offset = new Vector3(0f, OFFSET_Y, OFFSET_Z);
    [SerializeField] private float m_correctPlayerPoint = 1f;
    [SerializeField] private float m_rotateSpeed = 10f;

    void Start()
    {
        m_transform = transform;
    }

    void Update()
    {
        // プレイヤーを追いかける
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        //プレイヤーの位置情報を取得
        Transform playerTr = GameDirector.GetInstance().GetPlayerTr;

        // プレイヤーのいる方向へ回転
        Vector3 toPlayerVec = playerTr.position - m_transform.position;
        Quaternion rot = Quaternion.LookRotation(new Vector3(toPlayerVec.x, 0f, toPlayerVec.z), Vector3.up);
        m_transform.rotation = Quaternion.RotateTowards(m_transform.rotation, rot, m_rotateSpeed * Time.deltaTime);

        // 滑らかに移動
        m_transform.position = Vector3.Lerp(m_transform.position, playerTr.TransformPoint(m_offset), 0.3f);
    }
}
