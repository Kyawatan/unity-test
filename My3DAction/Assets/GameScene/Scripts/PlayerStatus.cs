using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatus : MobStatus
{
    [SerializeField] private Slider m_HPSlider;

    protected override void Start()
    {
        base.Start();
        m_HPSlider.value = m_lifeMax; // スライダを満タンにする
    }

    protected override void OnDie()
    {
        base.OnDie();
        StartCoroutine(GoToResultSceneCroutine());
    }

    private void Update()
    {
        m_HPSlider.value = m_life;
    }

    private IEnumerator GoToResultSceneCroutine()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("ResultScene");
    }
}
