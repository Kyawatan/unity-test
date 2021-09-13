using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotController : MonoBehaviour
{
    //private bool m_isExist = true; // 畑に残っていればtrue
    [SerializeField] private float m_stayTime = 3f;

    private float m_nowStayTime = 0f;

    void Start()
    {
        GameDirector.GetInstance.GetSetCarrotInfo = this.gameObject;
    }

    void Update()
    {
        
    }
}
