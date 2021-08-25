using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    private const float LIMIT_TIME = 20f;
    private Text m_timeText = null;
    private float m_remainingTime = LIMIT_TIME;

    void Start()
    {
        m_timeText = GetComponent<Text>();
    }

    void Update()
    {
        if (GameDirector.ms_instance.GetNowFlow() == GameDirector.GAME_FLOW.Playing)
        {
            //ゲームプレイ中は残り時間を減らす
            SubtractTime();
        }

        if (GameDirector.ms_instance.GetNowFlow() == GameDirector.GAME_FLOW.Ready)
        {
            if (m_remainingTime != LIMIT_TIME) InitTime(); //初期化
        }
    }

    private void SubtractTime()
    {
        m_remainingTime -= Time.deltaTime;
        m_timeText.text = m_remainingTime.ToString("F1");
    }

    private void InitTime()
    {
        //制限時間を初期化する
        m_remainingTime = LIMIT_TIME;
        m_timeText.text = m_remainingTime.ToString("F1");
    }

    public float GetTime()
    {
        //残り時間を返す
        return m_remainingTime;
    }
}
