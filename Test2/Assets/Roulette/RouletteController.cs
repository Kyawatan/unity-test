using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    const float MAX_SPEED = 600.0f; //初速
    const float DECELERATION_SPEED = 0.996f; //減速スピード
    float m_rotSpeed = 0.0f; //回転速度
    bool isStop;

    void Start()
    {
        isStop = true;
    }

    void Update()
    {
        if (isStop == true)
        {
            //ルーレットを減速させる
            m_rotSpeed *= DECELERATION_SPEED;

            //マウスが押されたらルーレットを回転させる
            if (Input.GetMouseButtonDown(0))
            {
                m_rotSpeed = Time.deltaTime * MAX_SPEED;
                isStop = false;
            }
        }
        else
        {
            //マウスが押されたらルーレットを止める
            if (Input.GetMouseButtonDown(0))
            {
                isStop = true;
            }
        }
        
        //回転速度分、ルーレットを回転させる
        //現在の角度からm_rotSpeed回転させる
        transform.Rotate(0, 0, m_rotSpeed);
    }
}
