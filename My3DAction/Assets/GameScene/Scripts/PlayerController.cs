using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private MobStatus m_status;
    [SerializeField] private float m_moveSpeed = 3f;    // 移動速度
    [SerializeField] private float m_rotateSpeed = 90f; // 回転速度
    //[SerializeField] private float m_jumpPower = 3f;    // ジャンプ力
    [SerializeField] private Animator m_animator;

    private Transform m_transform;
    private Rigidbody m_rigidbody;
    private Vector3 m_moveVelocity = Vector3.zero;

    void Start()
    {
        m_transform = this.transform;
        m_rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (m_status.IsNomalState)
        {
            //MovePlayer();
            AttackPlayer();
            //JumpPlayer();
        }

        // 歩行アニメーション
        m_animator.SetFloat("MoveSpeed", new Vector3(m_moveVelocity.x, 0f, m_moveVelocity.z).magnitude);
    }

    private void FixedUpdate()
    {
        if (m_status.IsNomalState)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        // 方向転換
        float playerAngle = Input.GetAxis("Horizontal") * m_rotateSpeed;
        //m_transform.eulerAngles += new Vector3(0f, playerAngle * Time.deltaTime, 0f);
        m_rigidbody.MoveRotation(Quaternion.Euler(transform.eulerAngles + new Vector3(0f, playerAngle * Time.deltaTime, 0f)));


        // 前進
        m_moveVelocity.z = Input.GetAxis("Vertical") * m_moveSpeed;
        //m_transform.position += m_transform.TransformDirection(m_moveVelocity) * Time.deltaTime;
        m_rigidbody.MovePosition(transform.position + m_transform.TransformDirection(m_moveVelocity) * Time.deltaTime);
    }

    private void AttackPlayer()
    {
        // 攻撃
        if (Input.GetButtonDown("Fire1"))
        {
            m_status.GoToAttackState();
        }
    }

    //private void JumpPlayer()
    //{
    //    // ジャンプ
    //    if (IsGrounded())
    //    {
    //        m_moveVelocity.y = 0f;
    //        if (Input.GetButtonDown("Jump")) m_moveVelocity.y = m_jumpPower;
    //    }
    //    else
    //    {
    //        m_moveVelocity.y += Physics.gravity.y * Time.deltaTime;
    //    }
    //}

    //private bool IsGrounded()
    //{
    //    Ray ray = new Ray(m_transform.position + Vector3.up * 0.1f, Vector3.down);
    //    RaycastHit hit;

    //    Debug.DrawRay(ray.origin, ray.direction, Color.red);

    //    if (Physics.Raycast(ray, out hit, 0.1f))
    //    {
    //        if (hit.distance <= 0.1 && hit.collider.tag == "Ground")
    //        {
    //            return true;
    //        }
    //        else return false;
    //    }
    //    else return false;
    //}

    public Transform GetPlayerTransform
    {
        get { return m_transform; }
    }
}
