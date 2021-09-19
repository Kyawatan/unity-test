using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMove : ObjectController
{
    [SerializeField] private float m_randMin = 0f;
    [SerializeField] private float m_randMax = 5f;

    private Animator m_animator;
    private float m_time = 0f;
    private float m_randTime;
    private bool m_isRun = true;

    //Transform m_earthTr;
    //private Vector3 m_thisLocalPos;
    //private Quaternion m_thisLocalRot;

    public float SetRandTime => Random.Range(m_randMin, m_randMax);

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_randTime = SetRandTime;

        // ゲームスタート時の地球から見たオブジェクトの座標を保持
        //m_earthTr = GameDirector.GetInstance.GetEarthTr;
        //m_thisLocalPos = m_earthTr.InverseTransformPoint(transform.position);
        //m_thisLocalRot = Quaternion.Inverse(m_earthTr.rotation) * transform.rotation;
    }

    private void Update()
    {
        // 地球の自転に合わせた移動・回転
        //transform.position = m_earthTr.TransformPoint(m_thisLocalPos);
        //transform.rotation = m_earthTr.rotation * m_thisLocalRot;

        // RootMotion移動
        //Vector3 move = m_animator.rootPosition - transform.position;
        //transform.position += move;

        TurnCenter();

        // ランダム移動
        m_time += Time.deltaTime;
        if (m_time >= m_randTime)
        {
            if (m_isRun)
            {
                transform.position += transform.up * Physics.gravity.y * Time.deltaTime; // Y座標補正
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
}
