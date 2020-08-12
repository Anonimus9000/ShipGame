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
    private FireSmokeController _fireSmoke;
    private float _timer;
    private enum CannonPosition
    {
        RightCannon,
        LeftCannon
    }
    void Awake()
    {
        _core = GetComponentInChildren<CoreController>();
        _fireSmoke = GetComponentInChildren<FireSmokeController>();
        _spawner = GetComponent<SpawnerCore>();
    }

    void Start()
    {

        _core.IncreaseDamageAccountCannon(_power);
    }

    void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
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
        if (_timer > _reloadTime && _core != null)
        {
            _fireSmoke.Play();
            _core.StartBallistics();
            _core = null;
            SpawnCore();
            _timer = 0;
        }
    }

    private void SpawnCore()
    {
        _core = _spawner.SpawnCore();
    }

}
