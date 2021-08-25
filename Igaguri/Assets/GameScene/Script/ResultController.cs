using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    const int LANKING_NUM = 5;
    [SerializeField] private Text m_scoreText = null;
    [SerializeField] private Text m_rank0Text = null;
    [SerializeField] private Text m_rank1Text = null;
    [SerializeField] private Text m_rank2Text = null;
    [SerializeField] private Text m_rank3Text = null;
    [SerializeField] private Text m_rank4Text = null;

    public void UpdateScoreRanking(List<int> rankings)
    {
        string score = GameDirector.ms_instance.m_totalPoint.ToString();
        m_scoreText.text = "SCORE :   " + score + " pt";
        score = rankings[0].ToString();
        m_rank0Text.text = "1 :   " + score + " pt";
        score = rankings[1].ToString();
        m_rank1Text.text = "2 :   " + score + " pt";
        score = rankings[2].ToString();
        m_rank2Text.text = "3 :   " + score + " pt";
        score = rankings[3].ToString();
        m_rank3Text.text = "4 :   " + score + " pt";
        score = rankings[4].ToString();
        m_rank4Text.text = "5 :   " + score + " pt";
    }

    private void OnEnable()
    {
        UpdateScoreRanking(GameDirector.ms_instance.m_pointRankings);
    }
}
