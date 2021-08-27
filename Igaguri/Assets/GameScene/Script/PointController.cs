using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour
{
    private Text m_text = null;
    private RectTransform m_rectTr;
    private float m_startPosY;
    private int m_point = 0;
    private float m_time = 0f;

    private void Awake()
    {
        m_text = GetComponent<Text>();
        m_rectTr = GetComponent<RectTransform>();
        m_startPosY = m_rectTr.position.y;
    }

    void Update()
    {
        //表示を上に移動
        const float MOVE_RATE = 20f;
        m_rectTr.position += new Vector3(0f, MOVE_RATE * Time.deltaTime, 0f);

        //1秒後に破棄
        m_time += Time.deltaTime;
        if (m_time >= 1f) Destroy(gameObject);
    }

    public void SetPoint(int pt)
    {
        m_point = pt;
        m_text.text = "+" + m_point + "pt";

        if (pt == 100) m_text.color = new Color(0.3961f, 0f, 0f, 1);
        else m_text.color = Color.white;
    }
}
