using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSmokeController : MonoBehaviour
{
    private ParticleSystem _fireSmoke;
    void Awake()
    {
        _fireSmoke = GetComponent<ParticleSystem>();
    }

    public void Play()
    {
        _fireSmoke.Play();
    }
}
