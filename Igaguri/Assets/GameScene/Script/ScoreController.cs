using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private Text m_scoreText = null;
    private int m_score = 0;

    private void Start()
    {
        m_scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        if (GameDirector.ms_instance.GetNowFlow() == GameDirector.GAME_FLOW.Ready)
        {
            if (m_score != 0) InitScore(); //初期化
        }
    }

    public void AddPoint(int point)
    {
        //加点する
        m_score += point;
        m_scoreText.text = m_score.ToString() + " pt";
    }

    public void InitScore()
    {
        //スコアを初期化する
        m_score = 0;
        m_scoreText.text = m_score.ToString() + " pt";
    }

    public int GetScore()
    {
        return m_score;
    }
}
