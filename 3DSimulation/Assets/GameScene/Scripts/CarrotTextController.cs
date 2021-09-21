using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarrotTextController : MonoBehaviour
{
    private Text m_carrotText = null;
    private int m_carrotNum = 1;

    private void Start()
    {
        m_carrotText = GetComponent<Text>();
        SetText();
    }

    private void SetText()
    {
        m_carrotText.text = "× " + m_carrotNum;
    }

    public int GetSetCarrotNum
    {
        get { return m_carrotNum; }
        set
        { 
            m_carrotNum += value;
            SetText();
        }
    }
}
