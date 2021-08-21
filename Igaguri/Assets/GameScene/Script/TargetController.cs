using UnityEngine;

public class TargetController : MonoBehaviour
{
    private bool isRotate = false;
    private Rigidbody m_rigidbody;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private const float COS_LOOP_TIME = 5f;   //1周する時間(s)
    private const float SIN_LOOP_TIME = 10f;
    private float m_time = 0f;

    void Update()
    {
        const float MOVE_W_RATE = 0.25f;
        const float MOVE_H_RATE = 0.2f;
        Vector3 now = m_rigidbody.position;
        //LoopTime(s)で一周する
        float cos = Mathf.Cos(m_time * Mathf.PI * 2 / COS_LOOP_TIME);
        float sin = Mathf.Sin(m_time * Mathf.PI * 2 / SIN_LOOP_TIME);

        //的を移動させる
        now += new Vector3(sin * MOVE_W_RATE, cos * MOVE_H_RATE, 0f);
        //target.position = now; ワープ移動になってフレーム間の当たり判定が消失するためダメ
        m_rigidbody.MovePosition(now);
        m_time += Time.deltaTime;
    }

    private Vector3 m_startAngle = Vector3.zero;
    private float m_angleY = 0f;

    private void FixedUpdate()
    {
        //的をY軸回転させる
        if (isRotate == true)
        {
            const float ROTATION_ANGLE = 1800f;

            m_rigidbody.MoveRotation(Quaternion.Euler(
                transform.eulerAngles + new Vector3(0f, ROTATION_ANGLE * Time.deltaTime, 0f)));
            
            m_angleY += ROTATION_ANGLE * Time.deltaTime;

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
