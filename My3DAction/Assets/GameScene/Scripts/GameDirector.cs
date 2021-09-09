﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    private static GameDirector ms_instance; // シングルトン

    [SerializeField] private CameraController m_cameraController;
    [SerializeField] private PlayerController m_playerController;

    private void Awake()
    {
        if (ms_instance == null) ms_instance = this;
    }

    public static GameDirector GetInstance()
    {
        //インスタンスを返す
        return ms_instance;
    }

    public Transform GetPlayerTr
    {
        //プレイヤーの位置情報を渡す
        get { return m_playerController.GetPlayerTransform; }
    }
}
