using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public static GameDirector ms_instance;

    [SerializeField] private GameObject m_resultPanel;
    [SerializeField] private TimeController m_timeText;
    [SerializeField] private ScoreController m_scoreText;
    private const int RANKING_NUM = 5;
    private GAME_FLOW m_nowFlow;
    private List<int> m_scoreRankings = new List<int>();
    
    void Awake()
    {
        if (ms_instance == null) ms_instance = this;

        //スコアランキングのロード
        LoadScoreRanking();
    }

    void Start()
    {
        //ゲーム開始時はタイトル画面を表示する
        m_nowFlow = GAME_FLOW.Ready;
        Debug.Log("Ready");
    }

    void Update()
    {
        switch (m_nowFlow)
        {
            case GAME_FLOW.Ready:
                if (Input.GetMouseButtonDown(0))
                {
                    m_nowFlow = GAME_FLOW.Playing;
                    Debug.Log("GameStart");
                }
                break;

            case GAME_FLOW.Playing:
                if (m_timeText.GetTime() > 0f)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        //ゲームプレイ中は右クリックでタイトル画面に戻る
                        m_nowFlow = GAME_FLOW.Ready;
                        Debug.Log("Ready");
                    }
                }
                else
                {
                    //ゲームが終了したらスコアランキングを更新してセーブする
                    SaveScoreRanking();

                    m_nowFlow = GAME_FLOW.Result;
                    Debug.Log("TimeUp");
                }
                break;

            case GAME_FLOW.Result:
                if (!m_resultPanel.activeSelf)
                {
                    //5秒リザルト画面を表示後、タイトル画面に戻る
                    StartCoroutine("ShowResult");
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

    private void LoadScoreRanking()
    {
        //スコアランキングのロード
        for (int i = 0; i < RANKING_NUM; i++)
        {
            int score = PlayerPrefs.GetInt("SCORE" + i, 0);
            m_scoreRankings.Add(score);
            Debug.Log(i + " : " + score);
        }
    }

    private void SaveScoreRanking()
    {
        int score = m_scoreText.GetScore();

        //今回のスコアが既にランキングにあるときはreturn
        for (int i = 0; i < RANKING_NUM; i++)
        {
            if (score == m_scoreRankings[i]) return;
        }

        //今回のスコアを配列に追加
        m_scoreRankings.Add(score);
        
        //降順ソートして上位5つのスコアをセーブ
        m_scoreRankings.Sort((a,b)  => b - a);
        for (int i = 0; i < RANKING_NUM; i++)
        {
            PlayerPrefs.SetInt("SCORE" + i, m_scoreRankings[i]);
        }
        PlayerPrefs.Save();
    }

    IEnumerator ShowResult()
    {
        m_resultPanel.SetActive(true);

        //5秒停止
        yield return new WaitForSeconds(5);

        //タイトル画面に戻る
        m_resultPanel.SetActive(false);
        m_nowFlow = GAME_FLOW.Ready;
        Debug.Log("Ready");
    }

    public GAME_FLOW GetNowFlow()
    {
        return m_nowFlow;
    }

    public List<int> GetScoreRankings()
    {
        return m_scoreRankings;
    }
}
