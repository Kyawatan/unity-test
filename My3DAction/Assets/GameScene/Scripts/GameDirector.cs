using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    private static GameDirector ms_instance; // シングルトン

    [SerializeField] private CameraController m_cameraController;
    [SerializeField] private PlayerController m_playerController;

    private GAME_FLOW m_nowFlow = GAME_FLOW.Ready; 
    private List<GameObject> m_carrotList = new List<GameObject>(); // ニンジンの情報格納用

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

    public bool IsExistCarrot => m_carrotList.Count != 0;

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

    public GameObject GetSetCarrotInfo
    {
        get { return m_carrotList[Random.Range(0, m_carrotList.Count)]; }
        set { m_carrotList.Add(value); }
    }

    public void RemoveCarrotList(GameObject carrot)
    {
        // リストからニンジンを削除
        m_carrotList.Remove(carrot);
        Destroy(carrot);
        Debug.Log("Destroy.");
        Debug.Log("残り : " + m_carrotList.Count);
        if (m_carrotList.Count == 0) GoToResultCroutine();
    }

    public void GoToResultCroutine()
    {
        // リザルト画面へ遷移
        StartCoroutine(GoToResultSceneCroutine());
    }

    private IEnumerator GoToResultSceneCroutine()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("ResultScene");
    }
}
