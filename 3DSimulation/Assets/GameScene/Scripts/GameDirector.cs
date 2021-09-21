using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField] private EarthController m_earth;
    [SerializeField] private GameObject m_tipsPanel;
    [SerializeField] private CarrotTextController m_carrotText;
    [SerializeField] private RabbitGenerator m_rabbitGenerator;

    private static GameDirector ms_instance;

    private void Awake()
    {
        if (ms_instance == null) ms_instance = this;
    }

    private void Update()
    {
        // 画面クリック判定
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;

                // ウサギをクリックしたとき
                if (hitObject.layer == 8 && hitObject.GetComponent<RabbitController>() != null)
                {
                    hitObject.GetComponent<RabbitController>().EatCarrot();
                }

                // チェストをクリックしたとき
                else if (hitObject.layer == 9 && hitObject.GetComponent<ChestController>() != null)
                {
                    hitObject.GetComponent<ChestController>().OpenChest();
                }
            }
        }
    }

    public static GameDirector GetInstance
    {
        get { return ms_instance; }
    }

    public Transform GetEarthTr
    {
        get { return m_earth.GetEarthTr; }
    }

    public int GetSetCarrotTextNum
    {
        get { return m_carrotText.GetSetCarrotNum; }
        set { m_carrotText.GetSetCarrotNum = value; }
    }

    public int SetGivenCarrotNum 
    { 
        set { m_rabbitGenerator.SetGivenCarrotNum = value; }
    }

    public void OnTipsPanel()
    {
        m_tipsPanel.SetActive(true);
    }
}
