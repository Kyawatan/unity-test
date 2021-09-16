using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalSphereScript : MonoBehaviour
{
    void Update()
    {
        transform.position += Vector3.forward * DirectorScript.GetInstance.GetMoveSpeed;
        transform.rotation = Quaternion.Euler(transform.eulerAngles + Vector3.right * DirectorScript.GetInstance.GetRotateSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 球に物を引っ付ける
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<TargetObjectScript>().GetSetIsFollowable = true;
        }
    }
}
