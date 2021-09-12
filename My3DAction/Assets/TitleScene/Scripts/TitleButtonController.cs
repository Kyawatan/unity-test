using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonController : MonoBehaviour
{
    [SerializeField] private Animator m_playerAnimator;

    public void OnClick()
    {
        StartCoroutine(GoToGameSceneCoroutine());
    }

    private IEnumerator GoToGameSceneCoroutine()
    {
        m_playerAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameScene");
    }
}
