using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CharactorControllerをアタッチ
//[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private float m_moveSpeed = 3f; // 移動速度
    [SerializeField] private float m_rotateSpeed = 90f; // 回転速度
    [SerializeField] private float m_jumpPower = 3f; // ジャンプ力
    //private CharacterController m_characterController;
    private Transform m_transform;
    private Vector3 m_moveVelocity = Vector3.zero;

    void Start()
    {
        //m_characterController = GetComponent<CharacterController>();
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
        m_transform.position += m_transform.TransformDirection(m_moveVelocity) * Time.deltaTime;

        m_animator.SetFloat("MoveSpeed", new Vector3(m_moveVelocity.x, 0f, m_moveVelocity.z).magnitude);
    
        if (Input.GetButtonDown("Fire1"))
        {
            // マウス左クリックで攻撃
            m_animator.SetTrigger("Attack");
        }
    }

    private void JumpPlayer()
    {
        if (IsGrounded())
        {
            m_moveVelocity.y = 0f;

            if (Input.GetButtonDown("Jump"))
            {
                // ジャンプ
                m_moveVelocity.y = m_jumpPower;
            }
        }
        else
        {
            // 重力による加速
            m_moveVelocity.y += Physics.gravity.y * Time.deltaTime;
        }
    }

    public bool IsGrounded()
    {
        Ray ray = new Ray(m_transform.position + Vector3.up * 0.1f, Vector3.down);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        if (Physics.Raycast(ray, out hit, 0.1f))
        {
            if (hit.distance <= 0.1 && hit.collider.tag == "Ground") return true;
            else return false;
        }
        else return false;
    }

    public Transform GetPlayerTransform
    {
        get { return m_transform; }
    }
}
