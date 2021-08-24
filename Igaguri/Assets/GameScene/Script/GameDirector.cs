using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    const int RANKING_NUM = 5;
    const float LIMIT_TIME = 20f;
    public static GameDirector ms_instance; //インスタンス化
    public GAME_FLOW m_nowFlow;
    public List<int> m_pointRankings = new List<int>();
    [SerializeField] private Text m_timeText = null;
    [SerializeField] private Text m_pointText = null;
    [SerializeField] private GameObject m_titleText;
    [SerializeField] private GameObject m_resultPanel;
    private float m_limitTime = LIMIT_TIME;    //制限時間
    private int m_totalPoint = 0;       //総得点
    
    void Awake()
    {
        if (ms_instance == null) ms_instance = this;

        //スコアランキングのロード
        LoadScoreRanking();
    }

    void Start()
    {
        m_resultPanel.SetActive(false);
        m_nowFlow = GAME_FLOW.Ready; 
    }

    void Update()
    {
        switch (m_nowFlow)
        {
            case GAME_FLOW.Ready:
                if (Input.GetMouseButtonDown(0))
                {
                    m_titleText.SetActive(false);
                    m_nowFlow = GAME_FLOW.Playing;
                    Debug.Log("GameStart");
                }
                break;

            case GAME_FLOW.Playing:
                if (m_limitTime > 0)
                {
                    //制限時間を減少させる
                    m_limitTime -= Time.deltaTime;
                }
                else
                {
                    //スコアランキングを更新してセーブする
                    SaveScoreRanking();

                    //2秒リザルト画面を表示してGAME_FLOW.Resultへ遷移
                    StartCoroutine("ShowResult");
                }
                m_timeText.text = m_limitTime.ToString("F1");
                m_pointText.text = m_totalPoint.ToString() + " pt";
                break;

            case GAME_FLOW.Result:
                if (Input.GetMouseButtonDown(0))
                {
                    m_resultPanel.SetActive(false);
                    m_titleText.SetActive(true);
                    m_limitTime = LIMIT_TIME;
                    m_totalPoint = 0;

                    m_nowFlow = GAME_FLOW.Ready;
                    Debug.Log("Retry");
                }
                break;
        } 
    }

    public enum GAME_FLOW
    {
        Ready,
        Playing,
        Result,
    }

    public void getPoint()
    {
        //加点する
        m_totalPoint += 10;
    }

    private void LoadScoreRanking()
    {
        //スコアランキングのロード
        for (int i = 0; i < RANKING_NUM; i++)
        {
            int score = PlayerPrefs.GetInt("SCORE" + i, 0);
            m_pointRankings.Add(score);
            Debug.Log(i + " : " + score);
        }
    }

    private void SaveScoreRanking()
    {
        //今回のスコアを配列に追加
        m_pointRankings.Add(m_totalPoint);

        //降順ソートして上位5つのスコアをセーブ
        m_pointRankings.Sort((a,b)  => b - a);
        for (int i = 0; i < RANKING_NUM; i++)
        {
            PlayerPrefs.SetInt("SCORE" + i, m_pointRankings[i]);
            Debug.Log(i + " : " + m_pointRankings[i]);
        }
        PlayerPrefs.Save();
    }

    IEnumerator ShowResult()
    {
        m_resultPanel.SetActive(true);

        //2秒停止
        yield return new WaitForSeconds(2);

        m_nowFlow = GAME_FLOW.Result;
        Debug.Log("TimeUp");
    }
}
