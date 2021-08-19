using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    private bool isRotate = false;

    void Start()
    {
        
    }

    void Update()
    {
        //的をY軸回転させる
        if (isRotate == true)
        {

        }
    }

    void FixedUpdate()
    {
        const float N1 = 3.0f;
        const float N2 = 8.0f;
        Rigidbody target = GetComponent<Rigidbody>();
        Vector3 now = target.position;
        float cos = Mathf.Cos(Time.time);
        float sin = Mathf.Sin(Time.time);

        //的を移動させる
        now += new Vector3(cos / N1, sin / N2, 0.0f);
        target.position = now;
    }

    private void OnCollisionEnter(Collision other)
    {
        //イガグリが当たったら的をY軸回転させる
        isRotate = true;
        Debug.Log("hit");
    }
}
