using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : ObjectController
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private float m_enableTime = 20f; // チェストの出現時間（s）

    private bool m_isOpened = false;
    private Coroutine m_coroutine;

    protected override void Start()
    {
        base.Start();
    }

    private void OnEnable()
    {
        RandomAppear();
        TurnCenter();

        // m_enableTime 秒後に非アクティブ化
        m_coroutine = StartCoroutine(OffChestCoroutine(m_enableTime));
    }

    public void RandomAppear()
    {
        float r = 7.5f;
        transform.rotation = Quaternion.AngleAxis(Random.Range(-90f, 90f), Vector3.right) * Quaternion.AngleAxis(Random.Range(-180f, 180f), Vector3.up);
        transform.position = transform.right * r;
        Debug.Log(transform.position);
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
