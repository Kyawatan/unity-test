using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorScript : MonoBehaviour
{
    [SerializeField] private Transform m_originalSphereTr;
    [SerializeField] private float m_moveSpeed = 10f;
    [SerializeField] private float m_rotateSpeed = 90f;

    private static DirectorScript ms_instance;

    private void Awake()
    {
        if (ms_instance == null) ms_instance = this;
    }

    public static DirectorScript GetInstance
    {
        get { return ms_instance; }
    }

    public Vector3 GetSpherePos
    {
        get { return m_originalSphereTr.position; }
    }

    public float GetMoveSpeed
    {
        get { return Input.GetAxis("Vertical") * m_moveSpeed * Time.deltaTime; }
    }

    public float GetRotateSpeed
    {
        get { return Input.GetAxis("Vertical") * m_rotateSpeed * Time.deltaTime; }
    }
}
