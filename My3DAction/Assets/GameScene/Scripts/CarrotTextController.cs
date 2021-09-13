using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarrotTextController : MonoBehaviour
{
    private Text m_carrotCounttext = null;

    private void Start()
    {
        m_carrotCounttext = GetComponent<Text>();
    }

    void Update()
    {
        int count = GameDirector.GetInstance.GetSetGetCarrotCount;
        m_carrotCounttext.text = "× " + count;
    }
}
