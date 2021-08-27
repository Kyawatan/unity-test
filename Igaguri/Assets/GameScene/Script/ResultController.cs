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

    [SerializeField] private ScoreController m_nowScore;

    public void UpdateScoreRanking(List<int> rankings)
    {
        int nowScore = m_nowScore.GetScore();
        Text[] rankingTexts = {m_rank0Text, m_rank1Text, m_rank2Text, m_rank3Text, m_rank4Text};

        //テキストの更新
        m_scoreText.text = "SCORE :   " + nowScore.ToString() + " pt";
        for (int i = 0; i < rankingTexts.Length; i++)
        {
            string score = rankings[i].ToString();
            rankingTexts[i].text = i + 1 + " :   " + score + " pt";
        }

        //今回のスコアがランキングに入っていたら文字の色を変える
        for(int i = 0; i < rankingTexts.Length; i++)
        {
            if(rankings[i] == nowScore)
            {
                rankingTexts[i].color = new Color(0.3961f, 0f, 0f, 1);
                return;
            }
        }
    }

    private void OnEnable()
    {
        UpdateScoreRanking(GameDirector.ms_instance.GetScoreRankings());
    }
}
