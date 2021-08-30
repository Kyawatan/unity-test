﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CharactorControllerをアタッチ
[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed = 3f; // 移動速度
    [SerializeField] private float m_rotateSpeed = 90f; // 回転速度
    [SerializeField] private float m_jumpPower = 3f; // ジャンプ力
    private CharacterController m_characterController;
    private Transform m_transform;
    private Vector3 m_moveVelocity = Vector3.zero;

    void Start()
    {
        m_characterController = GetComponent<CharacterController>();
        m_transform = transform;
    }

    void Update()
    {
        JumpPlayer();
        Debug.Log(m_characterController.isGrounded);

        //プレイヤーの方向を変える
        float playerAngle = Input.GetAxis("Horizontal") * m_rotateSpeed;
        m_transform.eulerAngles += new Vector3(0f, playerAngle * Time.deltaTime, 0f);

        //プレイヤーの前進
        m_moveVelocity.z = Input.GetAxis("Vertical") * m_moveSpeed;
        m_characterController.Move(m_transform.TransformDirection(m_moveVelocity) * Time.deltaTime);
        //m_transform.position +=  m_transform.forward * m_moveVelocity.z * Time.deltaTime;
    }

    private void JumpPlayer()
    {
        if (m_characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                // y方向に移動
                m_moveVelocity.y = m_jumpPower;
            }
        }
        else
        {
            // 重力による加速
            m_moveVelocity.y += Physics.gravity.y * Time.deltaTime;
        }
    }
}
