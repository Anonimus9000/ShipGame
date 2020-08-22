using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFireCannon : MonoBehaviour
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
