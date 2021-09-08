using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed = 3f;    // 移動速度
    [SerializeField] private float m_rotateSpeed = 90f; // 回転速度
    [SerializeField] private float m_jumpPower = 3f;    // ジャンプ力

    private Animator m_animator;
    private Transform m_transform;
    private Vector3 m_moveVelocity = Vector3.zero;

    void Start()
    {
        m_transform = transform;
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        // プレイヤーの方向を変える
        float playerAngle = Input.GetAxis("Horizontal") * m_rotateSpeed;
        m_transform.eulerAngles += new Vector3(0f, playerAngle * Time.deltaTime, 0f);

        // プレイヤーの前進
        m_moveVelocity.z = Input.GetAxis("Vertical") * m_moveSpeed;
        m_transform.position += m_transform.TransformDirection(m_moveVelocity) * Time.deltaTime;

        // プレイヤーをジャンプさせる
        if (IsGrounded())
        {
            m_moveVelocity.y = 0f;
            if (Input.GetButtonDown("Jump")) m_moveVelocity.y = m_jumpPower;
        }
        else
        {
            m_moveVelocity.y += Physics.gravity.y * Time.deltaTime;
        }

        // 歩行アニメーション
        m_animator.SetFloat("MoveSpeed", new Vector3(m_moveVelocity.x, 0f, m_moveVelocity.z).magnitude);
        
        // マウス左クリックで攻撃
        if (Input.GetButtonDown("Fire1")) m_animator.SetTrigger("Attack");
    }

    public bool IsGrounded()
    {
        Ray ray = new Ray(m_transform.position + Vector3.up * 0.1f, Vector3.down);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        if (Physics.Raycast(ray, out hit, 0.1f))
        {
            if (hit.distance <= 0.1 && hit.collider.tag == "Ground")
            {
                return true;
            }
            else return false;
        }
        else return false;
    }

    public Transform GetPlayerTransform
    {
        get { return m_transform; }
    }
}
