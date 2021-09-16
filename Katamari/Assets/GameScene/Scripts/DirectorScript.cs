using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorScript : MonoBehaviour
{
    [SerializeField] private Transform m_originalSphereTr;
    [SerializeField] private float m_moveSpeed = 10f;
    [SerializeField] private float m_rotateSpeed = 180f;

    private static DirectorScript ms_instance;

    private void Awake()
    {
        if (ms_instance == null) ms_instance = this;
    }

    public static DirectorScript GetInstance
    {
        get { return ms_instance; }
    }

    public Transform GetSphereTr
    {
        get { return m_originalSphereTr; }
    }

    public Vector3 GetMoveDirection
    {
        get { return new Vector3(Input.GetAxis("Horizontal"), 0f ,Input.GetAxis("Vertical")) * m_moveSpeed * Time.deltaTime; }
    }

    public Quaternion GetRotateDirection
    {
        get { return Quaternion.AngleAxis(m_rotateSpeed * Time.deltaTime, new Vector3(Input.GetAxis("Vertical"), 0f, -Input.GetAxis("Horizontal"))); }
    }
}
