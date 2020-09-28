using System;
using UnityEngine;

public class CoreController : MonoBehaviour
{
    [SerializeField] private float _damage = 1f;
    [SerializeField] private GameObject _chipsParticle;
    
    private DamageShipController _damageShips;
    private Ballistics _ballistics;
    private MeshRenderer _meshRenderer;
    private float _time;
    private ShipController _ship;
    private bool _isFire = false;

    private void Awake()
    {
        _ballistics = GetComponent<Ballistics>();
        _damageShips =  _chipsParticle.GetComponent<DamageShipController>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _meshRenderer.enabled = false;
    }

    private void FixedUpdate()
    {
        if (gameObject.transform.position.y < -6)
            Destroy(gameObject, 2);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Ship"))
        {
            print("Take ship");
            _damageShips.transform.position = gameObject.transform.position;
            _damageShips.Play();
            _ship = collider.GetComponent<ShipController>();
            if(_ship != null)
                _ship.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    public void StartBallistics()
    {
        _meshRenderer.enabled = true;
        _ballistics.StartBallistics(gameObject);
    }
    
    public void IncreaseDamageAccountCannon(float cannonPower)
    {
        _damage *= cannonPower;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}