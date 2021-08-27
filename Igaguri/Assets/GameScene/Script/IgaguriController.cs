using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgaguriController : MonoBehaviour
{
    private Rigidbody m_rigidbody;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.y < -10.0f || GameDirector.ms_instance.GetNowFlow() == GameDirector.GAME_FLOW.Ready)
        {
            Destroy(gameObject);
        }
    }

    public void Shoot(Vector3 dir)
    {
        //イガグリに力を加える
        m_rigidbody.AddForce(dir, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {

        TargetController target = collision.gameObject.GetComponent<TargetController>();
        
        if (target != null)
        {
            //的で処理させる
            target.AttachIgaguri(this, collision.contacts[0].point);
        }
    }
}
