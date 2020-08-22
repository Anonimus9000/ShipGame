using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSmokeController : MonoBehaviour
{
    private ParticleSystem _particle;
    void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
    }

    public void Play()
    {
        _particle.Play();
    }
}
