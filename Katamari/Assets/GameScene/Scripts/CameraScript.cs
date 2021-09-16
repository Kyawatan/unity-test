using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    void Update()
    {
        this.transform.position += DirectorScript.GetInstance.GetMoveDirection;
    }
}
