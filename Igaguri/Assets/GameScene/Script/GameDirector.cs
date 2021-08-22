using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    private GameObject m_time;
    private GameObject m_point;
    private Text m_timeText = null;
    private Text m_pointText = null;
    private float m_limitTime = 20f; //制限時間
    private int m_totalPoint = 0; //総得点

    void Start()
    {
        m_time = GameObject.Find("Time");
        m_point = GameObject.Find("Point");
        m_timeText = m_time.GetComponent<Text>();
        m_pointText = m_point.GetComponent<Text>();
    }

    void Update()
    {

        if (m_limitTime > 0)
        {
            //制限時間を減少させる
            m_limitTime -= Time.deltaTime;
        }

        m_timeText.text = m_limitTime.ToString("F1");
        m_pointText.text = m_totalPoint.ToString() + " pt";
    }

    public void getPoint()
    {
        //加点する
        m_totalPoint += 10;
    }
}
