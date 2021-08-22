using UnityEngine;

public class TargetController : MonoBehaviour
{
    private bool isRotate = false;
    private Rigidbody m_rigidbody;
    private Vector3 m_startPosition;    //的の開始位置

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_startPosition = m_rigidbody.position;
    }

    private const float COS_LOOP_TIME = 10f;   //1周する時間(s)
    private const float SIN_LOOP_TIME = 5f;
    private float m_time = 0f;

    void Update()
    {
        //縦横の移動範囲
        const float MOVE_W_RATE = 20f;
        const float MOVE_H_RATE = 8f;
        //LoopTime(s)で一周する
        float cos = Mathf.Cos(m_time * Mathf.PI * 2 / COS_LOOP_TIME);
        float sin = Mathf.Sin(m_time * Mathf.PI * 2 / SIN_LOOP_TIME);

        //的を移動させる
        m_rigidbody.MovePosition(
            m_startPosition + new Vector3(cos * MOVE_W_RATE, sin * MOVE_H_RATE, 0f));
        m_time += Time.deltaTime;
    }

    private Vector3 m_startAngle = Vector3.zero;
    private float m_angleY = 0f;

    private void FixedUpdate()
    {
        if (isRotate == true)
        {
            const float ROTATION_ANGLE = 1800f;

            //的をY軸回転させる
            m_rigidbody.MoveRotation(Quaternion.Euler(
                transform.eulerAngles + new Vector3(0f, ROTATION_ANGLE * Time.fixedDeltaTime, 0f)));
            m_angleY += ROTATION_ANGLE * Time.fixedDeltaTime;

            //1回転したら回転をリセットする
            if (m_angleY >= 360f)
            {
                m_angleY = 0;
                transform.eulerAngles = m_startAngle;
                isRotate = false;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //イガグリが当たったら的をY軸回転させる
        if (isRotate == false) isRotate = true;
    }
}
