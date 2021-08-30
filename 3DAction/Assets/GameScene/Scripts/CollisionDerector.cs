using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider))]

public class CollisionDerector : MonoBehaviour
{
    //[SerializeField] private TriggerEvent m_onTriggerStay = new TriggertEvent();

    void OnTriggerStay(Collider other)
    {
        //指定された処理を実行する
        //m_onTriggerStay.Invoke(other);
    }

    void Update()
    {
        
    }
}
