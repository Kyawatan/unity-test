using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearDirector : MonoBehaviour
{
    [SerializeField] GameObject m_plusCarrots;

    void Start()
    {
        int count = GameDirector.GetInstance.GetSetGetCarrotCount;
        if (count >= 10) m_plusCarrots.SetActive(true);
    }
}
