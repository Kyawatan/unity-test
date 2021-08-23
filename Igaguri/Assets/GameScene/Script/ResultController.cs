using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    const int LANKING_NUM = 5;
    [SerializeField] private Text m_lank0Text = null;
    [SerializeField] private Text m_lank1Text = null;
    [SerializeField] private Text m_lank2Text = null;
    [SerializeField] private Text m_lank3Text = null;
    [SerializeField] private Text m_lank4Text = null;

    void Update()
    {
        string score = GameDirector.ms_instance.m_pointLankings[0].ToString();
        m_lank0Text.text = "1 :   " + score + " pt";
        score = GameDirector.ms_instance.m_pointLankings[1].ToString();
        m_lank1Text.text = "2 :   " + score + " pt";
        score = GameDirector.ms_instance.m_pointLankings[2].ToString();
        m_lank2Text.text = "3 :   " + score + " pt";
        score = GameDirector.ms_instance.m_pointLankings[3].ToString();
        m_lank3Text.text = "4 :   " + score + " pt";
        score = GameDirector.ms_instance.m_pointLankings[4].ToString();
        m_lank4Text.text = "5 :   " + score + " pt";
    }
}
