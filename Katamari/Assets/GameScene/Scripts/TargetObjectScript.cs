using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObjectScript : MonoBehaviour
{
    private bool m_isFollowable = false;

    public bool GetSetIsFollowable
    {
        get { return m_isFollowable; }
        set { m_isFollowable = value; }
    }

    void Update()
    {
        if (!GetSetIsFollowable) return;

        Vector3 spherePos = DirectorScript.GetInstance.GetSpherePos;
        Vector3 toSphereVec = spherePos - transform.position;
        Vector3 angle = new Vector3(toSphereVec.x, 0f, toSphereVec.z);
        Quaternion rot = Quaternion.LookRotation(angle, Vector3.forward);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, DirectorScript.GetInstance.GetRotateSpeed);
        transform.position += Vector3.forward * DirectorScript.GetInstance.GetMoveSpeed;
    }
}
