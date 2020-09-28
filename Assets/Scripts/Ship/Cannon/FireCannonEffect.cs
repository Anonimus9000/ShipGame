using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FireCannonEffect : MonoBehaviour
{
    [SerializeField] private AudioClip _fireAudio;
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private ParticleSystem _smokeEffect;
    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        _audioSource.clip = _fireAudio;
        _audioSource.Play();
        _explosionEffect.Play();
        _smokeEffect.Play();
    }
}
