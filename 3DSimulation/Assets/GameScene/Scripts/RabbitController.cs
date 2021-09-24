using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : ObjectController
{
    [SerializeField] private GameObject m_carrot;
    [SerializeField] private float m_randMin = 0f;
    [SerializeField] private float m_randMax = 5f;

    private Animator m_animator;
    private RABBIT_STATE m_state = RABBIT_STATE.Normal;
    private float m_time = 0f;
    private float m_randTime;
    private bool m_isRun = true;

    private enum RABBIT_STATE
    {
        Normal,
        Eat,
    }

    public float SetRandTime => Random.Range(m_randMin, m_randMax);

    protected override void Start()
    {
        base.Start();

        m_carrot = transform.GetChild(3).gameObject; // ニンジンのオブジェクト取得
        m_animator = GetComponent<Animator>();
        m_randTime = SetRandTime;
    }

    private void Update()
    {
        TurnCenter();

        // ランダム移動
        m_time += Time.deltaTime;

        if (m_time >= m_randTime && m_state == RABBIT_STATE.Normal)
        {
            if (m_isRun)
            {
                //transform.position += transform.up * Physics.gravity.y * Time.deltaTime; // Y座標補正
                m_animator.SetInteger("TurnLR", 2);
                m_isRun = false;
            }
            else
            {
                m_animator.SetInteger("TurnLR", Random.Range(0, 2)); // 方向転換
                m_isRun = true;
            }

            m_time = 0f;
            m_randTime = SetRandTime;
        }
    }

    public void EatCarrot()
    {
        if (m_state == RABBIT_STATE.Eat || GameDirector.GetInstance.GetSetCarrotTextNum == 0) return;

        m_carrot.SetActive(true);
        m_animator.SetBool("isEatable", true);
        m_state = RABBIT_STATE.Eat;

        GameDirector.GetInstance.SetGivenCarrotNum = 1; ;
        GameDirector.GetInstance.GetSetCarrotTextNum = -1;
        StartCoroutine(StopEatCoroutine());
    }

    private IEnumerator StopEatCoroutine()
    {
        yield return new WaitForSeconds(3);

        m_carrot.SetActive(false);
        m_animator.SetBool("isEatable", false);
        m_state = RABBIT_STATE.Normal;
    }
}
