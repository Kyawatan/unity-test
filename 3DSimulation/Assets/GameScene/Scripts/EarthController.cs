using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController : MonoBehaviour
{
    [SerializeField] private float m_axisTilt = 23.4f; // 軸の傾き
    [SerializeField] private float m_rotationSpeed = 10f; // 自転速度

    private Quaternion rot;

    public Transform GetEarthTr
    {
        get { return transform; }
    }

    public Quaternion GetEarthRot
    {
        get { return rot; }
    }

    private void Update()
    {
        // 自転
        rot = Quaternion.AngleAxis(m_rotationSpeed * Time.deltaTime, transform.up);
        //rot = Quaternion.AngleAxis(m_rotationSpeed * Time.deltaTime, new Vector3(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), 0f));
        transform.rotation = rot * transform.rotation;
    }
}
