using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(GoToGameSceneCoroutine());
        }
    }

    private IEnumerator GoToGameSceneCoroutine()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameScene");
    }
}
