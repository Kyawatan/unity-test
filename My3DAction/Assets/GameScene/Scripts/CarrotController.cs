using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotController : MonoBehaviour
{
    private void Start()
    {
        GameDirector.GetInstance.GetSetCarrotInfo = this.gameObject;
    }
}
