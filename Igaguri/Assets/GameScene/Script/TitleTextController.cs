using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleTextController : MonoBehaviour
{
    [SerializeField] private Text m_titleText = null;
    private float m_time = 0f;

    private void Update()
    {
        //タイトルを点滅させる
        m_titleText.color = GetAlphaColor(m_titleText.color);
    }

    private Color GetAlphaColor(Color color)
    {
        const float FLASH_SPEED = 0.3f;

        //透明度を変化させる
        m_time += Time.deltaTime;
        color.a = Mathf.Sin(m_time / FLASH_SPEED);

        return color;
    }
}
