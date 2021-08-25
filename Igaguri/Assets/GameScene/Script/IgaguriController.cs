using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgaguriController : MonoBehaviour
{
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
        GetComponent<Rigidbody>().AddForce(dir, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        TargetController target = collision.gameObject.GetComponent<TargetController>();
        if (target != null)
        {
            //的で処理させる
            target.AttachIgaguri(this);
        }
    }
}
