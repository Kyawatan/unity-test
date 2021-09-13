using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MobStatus
{
    [SerializeField] private Slider m_HPSlider;
    [SerializeField] private ParticleController m_particle;

    protected override void Start()
    {
        base.Start();
        m_HPSlider.value = m_lifeMax; // スライダを満タンにする
    }

    protected override void OnDie()
    {
        base.OnDie();
        GameDirector.GetInstance.GoToResultCroutine();
    }

    public override void OnParticle()
    {
        base.OnParticle();
        m_particle.OnHitParticle(); // 攻撃パーティクルを再生
    }

    private void Update()
    {
        m_HPSlider.value = m_life;
    }
}
