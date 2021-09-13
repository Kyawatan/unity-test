using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem m_particle;

    public void Start()
    {
        m_particle = GetComponent<ParticleSystem>();
    }

    public void OnHitParticle()
    {
        m_particle.Play();
    }
}
