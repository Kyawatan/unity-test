using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    protected virtual void Start()
    {
        TurnCenter();
    }

    /// <summary>
    /// 足元を地球の中心方向へ回転
    /// </summary>
    protected void TurnCenter()
    {
        // 地球とオブジェクトとの垂直ベクトル
        Vector3 perpVec = GameDirector.GetInstance.GetEarthTr.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(-transform.up, perpVec) * transform.rotation;

        //Ray ray = new Ray(transform.position, -transform.up);
        //RaycastHit hit;

        //if (Physics.Raycast(ray, out hit, 0.05f))
        //{
        //    if (hit.collider.tag == "Earth")
        //    {
        //        transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        //    }
        //}

        //Debug.DrawRay(ray.origin, ray.direction, Color.red);
    }
}
