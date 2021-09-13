using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    private static GameDirector ms_instance; // シングルトン

    [SerializeField] private CameraController m_cameraController;
    [SerializeField] private PlayerController m_playerController;

    private bool m_isFinishGame = false;
    private int m_getCarrotCount = 0; // 納品したニンジンの数
    private List<GameObject> m_carrotList = new List<GameObject>(); // ニンジンの情報格納用

    private void Awake()
    {
        if (ms_instance == null) ms_instance = this;
    }

    public bool IsFinishGame => m_isFinishGame;

    public bool IsExistCarrot => m_carrotList.Count != 0;

    public static GameDirector GetInstance
    {
        //インスタンスを返す
        get { return ms_instance; }
    }

    public Transform GetPlayerTr
    {
        //プレイヤーの位置情報を渡す
        get { return m_playerController.GetPlayerTransform; }
    }

    public int GetSetGetCarrotCount
    {
        get { return m_getCarrotCount;  }
        set { m_getCarrotCount += value; }
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
        Debug.Log("残り : " + m_carrotList.Count);

        if (m_carrotList.Count == 0) GoToResultCroutine("true");
    }

    public void GoToResultCroutine(string end)
    {
        // リザルト画面へ遷移
        m_isFinishGame = true;
        if (end == "true") m_playerController.OnFinishAnim();
        StartCoroutine(GoToResultSceneCroutine(end));
    }

    private IEnumerator GoToResultSceneCroutine(string end)
    {
        yield return new WaitForSeconds(3);

        if (end == "true") SceneManager.LoadScene("TrueEndScene");
        else SceneManager.LoadScene("BadEndScene");
    }
}
