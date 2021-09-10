using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotController : MonoBehaviour
{
    //private bool m_isExist = true; // 畑に残っていればtrue

    void Start()
    {
        GameDirector.GetInstance.GetSetCarrotInfo = this.transform.position;
    }

    void Update()
    {
        
    }
}
