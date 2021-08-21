using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgaguriController : MonoBehaviour
{
    GameObject target;

    void Start()
    {
        target = GameObject.Find("target");
    }

    private void Update()
    {
        if (transform.position.y < -10.0f)
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
        //イガグリの動作を停止させる
        GetComponent<Rigidbody>().isKinematic = true;

        //イガグリの当たり判定を停止
        GetComponent<Collider>().enabled = false;

        //イガグリを的に固定する（親子関係にする）
        gameObject.transform.parent = target.gameObject.transform;
    }
}
