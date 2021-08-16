using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI部品を使うために必要

public class GameDirector : MonoBehaviour
{
    GameObject car;
    GameObject flag;
    GameObject distance;
    private Text m_distanceText = null;

    void Start()
    {
        this.car = GameObject.Find("car");
        this.flag = GameObject.Find("flag");
        this.distance = GameObject.Find("Distance");
        m_distanceText = distance.GetComponent<Text>();
    }

    void Update()
    {
        float length = this.flag.transform.position.x - this.car.transform.position.x;
        if (length >= 0)
        {
            m_distanceText.text = "ゴールまで" + length.ToString("F2") + "m";
        }
        else
        {
            m_distanceText.text = "ゲームオーバー";
        }
    }
}
