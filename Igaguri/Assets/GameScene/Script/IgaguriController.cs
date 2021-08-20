﻿using System.Collections;
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
        GetComponent<Rigidbody>().AddForce(dir);
    }

    private void OnCollisionEnter(Collision other)
    {
        //イガグリの動作を停止させる
        GetComponent<Rigidbody>().isKinematic = true;

        //イガグリを的に固定する（親子関係にする）
        gameObject.transform.parent = target.gameObject.transform;
    }
}
