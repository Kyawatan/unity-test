using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouletteDirector : MonoBehaviour
{
    GameObject m_roulette;
    GameObject m_text;
    Text m_omikujiText = null;
    const int ANGLE = 60;
    const int ANGLE_COLLECTION = 30;
    float m_angleZ = 0.0f; //ルーレットの回転角度

    void Start()
    {
        m_roulette = GameObject.Find("roulette");
        m_text= GameObject.Find("Text");
        m_omikujiText = m_text.GetComponent<Text>();
    }

    void Update()
    {
        //ルーレットの回転角度を取得する
        //初期角度からどのくらい回転しているかを取得する
        m_angleZ = m_roulette.transform.localEulerAngles.z;
        //Debug.Log(m_angleZ);

        int result = ((int)m_angleZ + ANGLE_COLLECTION) / ANGLE;
        Debug.Log(result);

        //回転角度によっておみくじの結果を表示する
        switch (result)
        {
            case 1:
                m_omikujiText.text = "大吉";
                break;
            case 2:
                m_omikujiText.text = "大凶";
                break;
            case 3:
                m_omikujiText.text = "小吉";
                break;
            case 4:
                m_omikujiText.text = "末吉";
                break;
            case 5:
                m_omikujiText.text = "中吉";
                break;
            default:
                m_omikujiText.text = "凶";
                break;
        }
    }
}