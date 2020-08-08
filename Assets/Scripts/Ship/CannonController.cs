using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private float _power = 2f;
    [SerializeField] private float _reloadTime = 1f;
    [SerializeField] private Ballistics _ballistics;
    [SerializeField] private CannonPosition _cannonPosition;
    
    private CoreController _core;
    private SpawnerCore _spawner;
    private float _timer;
    private bool _coreIsSpawned = true;
    private enum CannonPosition
    {
        RightCannon,
        LeftCannon
    }
    void Awake()
    {
        _core = GetComponentInChildren<CoreController>();

        _spawner = GetComponent<SpawnerCore>();

        _ballistics = GetComponent<Ballistics>();
    }

    void Start()
    {
        _core.IncreaseDamageAccountCannon(_power);
    }
    void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
        
        Reload();
    }

    public CoreController GetCore()
    {
        return _core;
    }
    public bool IsRightCannon()
    {
        if (_cannonPosition == CannonPosition.RightCannon)
            return true;
        else
            return false;
    }
    
    public void Fire()
    {
        if (_timer > _reloadTime)
        {
            _coreIsSpawned = false;
            if(_core != null)
                _ballistics.StartBallistics();
        }
    }

    private void SpawnCore()
    {
        _core = _spawner.SpawnCore();
    }

    private void Reload()
    {
        if (_coreIsSpawned == false)
        {
            _coreIsSpawned = true;
            SpawnCore();
            _ballistics.SetBullet(_core.gameObject);
        }
    }
}
