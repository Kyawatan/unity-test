using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    private static GameDirector ms_instance; //シングルトン

    [SerializeField] private CameraController m_cameraController;
    [SerializeField] private PlayerController m_playerController;
    [SerializeField] private EnemyMove m_enemyMove;

    private void Awake()
    {
        if (ms_instance == null) ms_instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {

    }

    public static GameDirector GetInstance()
    {
        //インスタンスを返す
        return ms_instance;
    }

    public Transform GetPlayerTr()
    {
        //プレイヤーの位置情報を渡す
        return m_playerController.GetPlayerTransform();
    }
}
