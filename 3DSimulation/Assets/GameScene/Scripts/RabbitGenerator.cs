using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitGenerator : MonoBehaviour
{
    [SerializeField] private GameObject m_rabbitsBox;
    [SerializeField] private int m_requiredCarrotNum = 5; // 新しいウサギを出現させるために必要なニンジンの数

    private List<GameObject> m_rabbits = new List<GameObject>();
    private int m_givenCarrotNum = 0; // ウサギにニンジンをあたえた数
    private int m_rabbitsIndex = 0;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            m_rabbits.Add(m_rabbitsBox.transform.GetChild(i).gameObject);
        }

        m_rabbits[m_rabbitsIndex].SetActive(true);
        m_rabbitsIndex++;
    }

    private void Update()
    {
        if (m_givenCarrotNum == m_requiredCarrotNum) OnRabbit();
    }

    public int SetGivenCarrotNum
    {
        set { m_givenCarrotNum++; }
    }

    public void OnRabbit()
    {
        m_rabbits[m_rabbitsIndex].SetActive(true);
        m_rabbitsIndex++;
        m_requiredCarrotNum += m_requiredCarrotNum;

        GameDirector.GetInstance.OnTipsPanel(); // Tips表示
    }
}
