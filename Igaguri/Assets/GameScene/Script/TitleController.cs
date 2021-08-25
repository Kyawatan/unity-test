using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    private Text m_titleText = null;
    private float m_time = 0f;

    private void Start()
    {
        m_titleText = gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        if (GameDirector.ms_instance.GetNowFlow() == GameDirector.GAME_FLOW.Ready)
        {
            if (!m_titleText.enabled) m_titleText.enabled = true; //テキストを表示

            //タイトル画面ではタイトルを点滅させる
            m_titleText.color = GetAlphaColor(m_titleText.color);
        }
        else
        {
            if (m_titleText.enabled) m_titleText.enabled = false; //テキストを非表示
        }
    }

    private Color GetAlphaColor(Color color)
    {
        const float FLASH_SPEED = 2.5f;

        //透明度を変化させる
        m_time += Time.deltaTime;
        color.a = Mathf.Abs(Mathf.Cos(m_time * Mathf.PI / FLASH_SPEED));

        return color;
    }
}
