using System.Collections;
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

        // プレイヤーの方向を変える
        float playerAngle = Input.GetAxis("Horizontal") * m_rotateSpeed;
        m_transform.eulerAngles += new Vector3(0f, playerAngle * Time.deltaTime, 0f);
        //m_transform.rotation = Quaternion.Euler();

        // プレイヤーの前進
        m_moveVelocity.z = Input.GetAxis("Vertical") * m_moveSpeed;
        //m_characterController.Move(m_transform.TransformDirection(m_moveVelocity) * Time.deltaTime);
        //m_transform.position +=  m_transform.forward * m_moveVelocity.z * Time.deltaTime;
        m_transform.position +=  m_moveVelocity * Time.deltaTime;
    }

    private void JumpPlayer()
    {
        if (IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                // ジャンプ
                m_moveVelocity.y = m_jumpPower;
            }
            Debug.Log("a");
        }
        else
        {
            // 重力による加速
            m_moveVelocity.y += Physics.gravity.y * Time.deltaTime;
            Debug.Log("b");
        }
    }

    public bool IsGrounded()
    {
        Ray ray = new Ray(m_transform.position + Vector3.up * 0.1f, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 0.2f))
        {
            if (hit.collider.tag == "Ground") return true;
            else return false;
        }
        else return false;
    }

    public Transform GetPlayerTransform
    {
        get { return m_transform; }
    }
}
