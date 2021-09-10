using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    private static GameDirector ms_instance; // シングルトン

    [SerializeField] private CameraController m_cameraController;
    [SerializeField] private PlayerController m_playerController;

    private GAME_FLOW m_nowFlow = GAME_FLOW.Ready; 
    private List<Vector3> m_carrotList = new List<Vector3>(); // ニンジンの情報格納用

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

    public static GameDirector GetInstance
    {
        //インスタンスを返す
        get { return ms_instance; }
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

    public Vector3 GetSetCarrotInfo
    {
        get { return m_carrotList[Random.Range(0, m_carrotList.Count)]; }
        set { m_carrotList.Add(value); }
    }

    public bool IsExistCarrot => m_carrotList.Count != 0;
}
