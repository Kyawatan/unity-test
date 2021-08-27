using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] private PointController m_point;
    [SerializeField] private Transform m_centerTr;
    private bool m_isRotate = false;
    private Rigidbody m_rigidbody;
    private Vector3 m_startPosition; //的の初期位置
    private float m_time = 0f;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_startPosition = m_rigidbody.position;
    }

    void Update()
    {
        if (GameDirector.ms_instance.GetNowFlow() == GameDirector.GAME_FLOW.Playing)
        {
            //ゲームプレイ中は的を移動させる
            //MoveTarget();
        }

        if (GameDirector.ms_instance.GetNowFlow() == GameDirector.GAME_FLOW.Ready)
        {
            if (m_rigidbody.position != m_startPosition) InitTarget(); //初期化       
        }
    }

    private void FixedUpdate()
    {
        if (m_isRotate)
        {
            RotateOnceTarget();
        }
    }

    private void MoveTarget()
    {
        //1周する時間(s)
        const float LOOP_W_TIME = 10f;
        const float LOOP_H_TIME = 5f;
        //縦横の移動範囲
        const float MOVE_W_RATE = 20f;
        const float MOVE_H_RATE = 8f;
        //LoopTime(s)で一周する
        float xSin = Mathf.Sin(m_time * Mathf.PI * 2 / LOOP_W_TIME);
        float ySin = Mathf.Sin(m_time * Mathf.PI * 2 / LOOP_H_TIME);

        //的を移動させる
        m_rigidbody.MovePosition(
            m_startPosition + new Vector3(xSin * MOVE_W_RATE, ySin * MOVE_H_RATE, 0f));
        m_time += Time.deltaTime;
    }

    private Vector3 m_startAngle = Vector3.zero;
    private float m_angleY = 0f;

    private void RotateOnceTarget()
    {
        const float ROTATION_ANGLE = 1800f;

        //的をY軸回転させる
        m_rigidbody.MoveRotation(Quaternion.Euler(
            transform.eulerAngles + new Vector3(0f, ROTATION_ANGLE * Time.fixedDeltaTime, 0f)));
        m_angleY += ROTATION_ANGLE * Time.fixedDeltaTime;

        //1回転したら回転をリセットする
        if (m_angleY >= 360f)
        {
            m_angleY = 0f;
            transform.eulerAngles = m_startAngle;
            m_isRotate = false;
        }
    }

    private void InitTarget()
    {
        //的の位置を初期化
        m_rigidbody.position = m_startPosition;
        m_time = 0f;
    }

    public void AttachIgaguri(IgaguriController igaguri, Vector3 contact)
    {
        //ワールド座標からローカル座標へ変換
        Vector2 contactPos = new Vector2(contact.x, contact.y);
        Vector2 centerPos = new Vector2(m_centerTr.position.x, m_centerTr.position.y);
        float distance = (contactPos - centerPos).magnitude;
        int point = 0;

        if (distance < 0.3f) point = 100;
        else if (0.3f <= distance && distance < 1f) point = 50;
        else if (1f <= distance && distance < 1.55f) point = 20;
        else if (1.55f <= distance && distance < 2.15f) point = 10;
        else return;

        //スコアを加点
        m_point.AddPoint(point);

        Debug.Log(transform);
        Debug.Log(contactPos + " , " + centerPos);
        Debug.Log(distance);

        //的をY軸回転
        m_isRotate = true;

        //イガグリの動作と当たり判定を停止
        igaguri.GetComponent<Rigidbody>().isKinematic = true;
        igaguri.GetComponent<Collider>().enabled = false;

        //イガグリを的に固定する（親子関係にする）
        igaguri.transform.parent = m_centerTr;
    }
}
