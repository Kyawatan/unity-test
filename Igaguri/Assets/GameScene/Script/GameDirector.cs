using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    const int LANKING_NUM = 5;
    const float LIMIT_TIME = 20f;
    public static GameDirector ms_instance; //インスタンス化
    public GAME_FLOW m_nowFlow;
    public List<int> m_pointLankings = new List<int>();
    [SerializeField] private Text m_timeText = null;
    [SerializeField] private Text m_pointText = null;
    [SerializeField] private Text m_titleText = null;
    [SerializeField] private GameObject m_resultPanel;
    private float m_limitTime = LIMIT_TIME;    //制限時間
    private int m_totalPoint = 0;       //総得点
    
    void Awake()
    {
        if (ms_instance == null) ms_instance = this;

        //スコアランキングのロード
        LoadScoreLanking();
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
                //タイトルを点滅させる
                m_titleText.color = GetAlphaColor(m_titleText.color);

                if (Input.GetMouseButtonDown(0))
                {
                    m_titleText.enabled = false;
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
                    SaveScoreLanking();

                    m_nowFlow = GAME_FLOW.Result;
                    Debug.Log("TimeUp");
                }
                m_timeText.text = m_limitTime.ToString("F1");
                m_pointText.text = m_totalPoint.ToString() + " pt";
                break;

            case GAME_FLOW.Result:
                m_resultPanel.SetActive(true);

                if (Input.GetMouseButtonDown(0))
                {
                    m_resultPanel.SetActive(false);
                    m_titleText.enabled = true;
                    m_limitTime = LIMIT_TIME;
                    m_totalPoint = 0;

                    m_nowFlow = GAME_FLOW.Ready;
                    Debug.Log("Return");
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

    float m_time = 0f;

    private Color GetAlphaColor(Color color)
    {
        const float FLASH_SPEED = 0.3f;
 
        //透明度を変化させる
        m_time += Time.deltaTime;
        color.a = Mathf.Sin(m_time / FLASH_SPEED);

        return color;
    }

    private void LoadScoreLanking()
    {
        //スコアランキングのロード
        for (int i = 0; i < LANKING_NUM; i++)
        {
            int score = PlayerPrefs.GetInt("SCORE" + i, 0);
            m_pointLankings.Add(score);
            Debug.Log(i + " : " + score);
        }
    }

    private void SaveScoreLanking()
    {
        //今回のスコアを配列に追加
        m_pointLankings.Add(m_totalPoint);

        //降順ソートして上位5つのスコアをセーブ
        m_pointLankings.Sort((a,b)  => b - a);
        for (int i = 0; i < LANKING_NUM; i++)
        {
            PlayerPrefs.SetInt("SCORE" + i, m_pointLankings[i]);
            Debug.Log(i + " : " + m_pointLankings[i]);
        }
        PlayerPrefs.Save();
    }
}
