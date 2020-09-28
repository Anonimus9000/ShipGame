using System.Collections;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private float _power = 2f;
    [SerializeField] private float _reloadTime = 1f;
    [SerializeField] private CannonPosition _cannonPosition;
    [SerializeField] private CoreController _prefabCore;
   
    [Space(2)]
    [Header("Random time to fire between this value")]
    [SerializeField]private float _firstValue = 0f;
    [SerializeField]private float _secondValue = 2f;

    private CoreController _core;
    private FireCannonEffect _fireCannonEffect;
    private SpawnerCore _spawner;
    private float _timer;

    private enum CannonPosition
    {
        RightCannon,
        LeftCannon
    }

    private void Awake()
    {
        _core = GetComponentInChildren<CoreController>();
        _spawner = GetComponent<SpawnerCore>();
        _core.IncreaseDamageAccountCannon(_power);
        _fireCannonEffect = GetComponent<FireCannonEffect>();
    }

    private void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
        if(_core != null)
            Debug.Log(_core.name);
        else
            Debug.Log("Core is null");
    }

    public bool IsRightCannon()
    {
        if (_cannonPosition == CannonPosition.RightCannon)
            return true;
        return false;
    }

    public void Fire()
    {  //Не включает партиклы, не может стрелять больше одного раза
        if (_timer > _reloadTime && _core != null)
        {
            RandTimeToStartBallistics(_firstValue, _secondValue);
            _core = null;
            SpawnCore();
            _timer = 0;
        }
    }

    private void SpawnCore()
    {
        _core = _spawner.SpawnCore();
    }
    
    private void RandTimeToStartBallistics(float firstTimeValue, float secondTimeValue)
    {
        gameObject.SetActive(true);
        StartCoroutine(StartRandBallistics(firstTimeValue, secondTimeValue));
    }
    
    private IEnumerator StartRandBallistics(float firstTimeValue, float secondTimeValue)
    {
        CoreController core = _core;
        float randomValueTime = Random.Range(firstTimeValue, secondTimeValue);

        yield return new WaitForSeconds(randomValueTime);
        core.StartBallistics();
        _fireCannonEffect.Play();
    }
}