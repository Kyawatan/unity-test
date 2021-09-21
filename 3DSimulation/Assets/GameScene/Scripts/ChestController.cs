using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private float m_enableTime = 20f; // チェストの出現時間（s）

    private Animator m_animator;
    private bool m_isOpened = false;
    private Coroutine m_coroutine;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // m_enableTime 秒後に非アクティブ化
        m_coroutine = StartCoroutine(OffChestCoroutine(m_enableTime));
    }

    public void OpenChest()
    {
        if (m_isOpened) return;

        m_isOpened = true;
        m_animator.SetTrigger("Open");
        StopCoroutine(m_coroutine);
        StartCoroutine(OffChestCoroutine(3f));

        int num = Random.Range(2, 6);
        GameDirector.GetInstance.GetSetCarrotTextNum = num;
    }

    private IEnumerator OffChestCoroutine(float sec)
    {
        yield return new WaitForSeconds(sec);
       
        if (m_isOpened)
        {
            m_isOpened = false;
            m_animator.SetTrigger("Reset");
        }

        gameObject.SetActive(false);
    }
}
