using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField] private EarthController m_earth;

    private static GameDirector ms_instance;

    private void Awake()
    {
        if (ms_instance == null) ms_instance = this;
    }

    public static GameDirector GetInstance
    {
        get { return ms_instance; }
    }

    public Transform GetEarthTr
    {
        get { return m_earth.GetEarthTr; }
    }

    public bool OnChest => Time.time >= 30f;

    public bool OnNewRabbit => Time.time % 60f >= 1f;
}
