using UnityEngine;

public class TargetController : MonoBehaviour
{
    public static bool m_isMove = false;
    private bool m_isRotate = false;
    private Rigidbody m_rigidbody;
    private Vector3 m_startPosition;    //的の開始位置
    private float m_time = 0f;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_startPosition = m_rigidbody.position;
    }

    void Update()
    {
        if (m_isMove)
        {
            MoveTarget();
        }
        else
        {
            m_rigidbody.position = m_startPosition;
            m_time = 0f;
        }
    }

    private void FixedUpdate()
    {
        if (m_isRotate)
        {
            RotateTarget();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //イガグリが当たったら的をY軸回転させる
        if (!m_isRotate) m_isRotate = true;

        //ポイントを加点する
        GameDirector.ms_instance.getPoint();
    }

    private const float LOOP_W_TIME = 10f;   //1周する時間(s)
    private const float LOOP_H_TIME = 5f;

    private void MoveTarget()
    {
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

    private void RotateTarget()
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
}
