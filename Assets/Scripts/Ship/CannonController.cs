using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CannonController : MonoBehaviour
{
    [SerializeField] private float _power = 2f;
    [SerializeField] private float _reloadTime = 1f;
    [SerializeField] private CannonPosition _cannonPosition;
    [Space(2)]
    [Header("Random time to fire between this value")]
    [SerializeField]private float _firstValue = 0f;
    [SerializeField]private float _secondValue = 2f;

    private CoreController _core;
    private SpawnerCore _spawner;
    private FireSmokeController _fireSmoke;
    private float _timer;

    private enum CannonPosition
    {
        RightCannon,
        LeftCannon
    }

    private void Awake()
    {
        _core = GetComponentInChildren<CoreController>();
        _fireSmoke = GetComponentInChildren<FireSmokeController>();
        _spawner = GetComponent<SpawnerCore>();
        _core.IncreaseDamageAccountCannon(_power);
    }

    private void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
    }

    public bool IsRightCannon()
    {
        if (_cannonPosition == CannonPosition.RightCannon)
            return true;
        return false;
    }

    public void Fire()
    {
        if (_timer > _reloadTime && _core != null)
        {
            _fireSmoke.Play();
            _core.RandTimeToStartBallistics(_firstValue, _secondValue);
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