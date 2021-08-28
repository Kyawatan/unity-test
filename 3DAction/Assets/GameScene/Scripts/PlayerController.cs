using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CharactorControllerをアタッチ
[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed = 3f; // 移動速度
    [SerializeField] private float m_jumpPower = 3f; // ジャンプ力
    private CharacterController m_characterController;
    private Transform m_transform;
    private Vector3 m_moveVelocity;

    void Start()
    {
        m_characterController = GetComponent<CharacterController>();
        m_transform = transform;
    }

    void Update()
    {
        JumpPlayer();
        LookMoveDirection();
        m_characterController.Move(m_moveVelocity * Time.deltaTime);
    }

    private void LookMoveDirection()
    {
        m_moveVelocity.x = Input.GetAxis("Horizontal") * m_moveSpeed;
        m_moveVelocity.z = Input.GetAxis("Vertical") * m_moveSpeed;
        // 移動方向に向く
        m_transform.LookAt(m_transform.position + new Vector3(m_moveVelocity.x, 0f, m_moveVelocity.z));
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
