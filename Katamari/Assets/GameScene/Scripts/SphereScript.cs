using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    [SerializeField] private float m_speed = 1000f; // 調節用

    private Rigidbody m_rigidbody;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        m_rigidbody.AddForce(DirectorScript.GetInstance.GetMoveDirection * m_speed, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 球に物を引っ付ける
        if (collision.gameObject.layer == 8)
        {
            collision.transform.parent = this.transform;
            collision.gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
