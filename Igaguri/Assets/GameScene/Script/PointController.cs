using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour
{
    private Text m_pointText = null;
    private int m_totalPoint = 0;

    private void Start()
    {
        m_pointText = GetComponent<Text>();
    }

    private void Update()
    {
        if (GameDirector.ms_instance.GetNowFlow() == GameDirector.GAME_FLOW.Ready)
        {
            if (m_totalPoint != 0) InitPoint(); //初期化
        }
    }

    public void AddPoint(int point)
    {
        //加点する
        m_totalPoint += point;
        m_pointText.text = m_totalPoint.ToString() + " pt";
    }

    public void InitPoint()
    {
        //スコアを初期化する
        m_totalPoint = 0;
        m_pointText.text = m_totalPoint.ToString() + " pt";
    }

    public int GetPoint()
    {
        return m_totalPoint;
    }
}
