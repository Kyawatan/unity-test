using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    private static GameDirector ms_instance; // シングルトン

    [SerializeField] private CameraController m_cameraController;
    [SerializeField] private PlayerController m_playerController;

    private GAME_FLOW m_nowFlow = GAME_FLOW.Ready;

    private void Awake()
    {
        if (ms_instance == null) ms_instance = this;
    }

    public enum GAME_FLOW
    {
        Ready,
        Playing,
        Result,
    }

    public static GameDirector GetInstance()
    {
        //インスタンスを返す
        return ms_instance;
    }

    public GAME_FLOW GetNowFlow
    {
        get { return m_nowFlow; }
    }

    public Transform GetPlayerTr
    {
        //プレイヤーの位置情報を渡す
        get { return m_playerController.GetPlayerTransform; }
    }
}
