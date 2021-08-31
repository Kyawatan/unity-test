using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField] private CameraController m_cameraController;
    [SerializeField] private PlayerController m_playerController;
    [SerializeField] private EnemyMove m_enemyMove;

    void Start()
    {
        
    }

    void Update()
    {
        // プレイヤーの位置情報をカメラと敵に渡す
        m_cameraController.CameraPosition(m_playerController.GetPlayerPosition());
        m_enemyMove.MoveToPlayer(m_playerController.GetPlayerPosition());
    }
}
