using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalSphereScript : MonoBehaviour
{
    void Update()
    {
        transform.position += DirectorScript.GetInstance.GetMoveDirection;
        transform.rotation = DirectorScript.GetInstance.GetRotateDirection * transform.rotation;
    }

    private void OnTriggerEnter(Collider collision)
    {
        // 球に物を引っ付ける
        if (collision.gameObject.layer == 8)
        {
            var collider = collision.gameObject.GetComponent<TargetObjectScript>();

            if (collider != null)
            {
                collider.OnIsFollowable(collision.transform);
            }
        }
    }
}
