using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    protected virtual void Awake()
    {
        TurnCenter();
    }

    /// <summary>
    /// 足元を地球の中心方向へ回転
    /// </summary>
    protected void TurnCenter()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 0.05f))
        {
            if (hit.collider.tag == "Earth")
            {
                transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            }
        }

        Debug.DrawRay(ray.origin, ray.direction, Color.red);
    }
}
