using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private float _power = 2f;
    [SerializeField] private float _reloadTime = 1f;
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
    }

    void Start()
    {
        _core.IncreaseDamageAccountCannon(_power);
    }
    void Update()
    {
        _timer += Time.deltaTime;

        Reload();
    }
    public bool IsRightCannon()
    {
        if (_cannonPosition == CannonPosition.RightCannon)
            return true;
        else
            return false;
    }
    public CoreController GetCore()
    {
        return _core;
    }

    public void Fire()
    {
        if (_timer > _reloadTime)
        {
            _coreIsSpawned = false;
            if(_core != null)
                _core.Fire();
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
        }
    }
}
