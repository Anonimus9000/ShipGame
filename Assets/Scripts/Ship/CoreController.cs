using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class CoreController : MonoBehaviour
{
    [SerializeField] private float _damage = 1f;
    private Ballistics _ballistics;
    private float _time;
    private ShipController _ship;
    private bool _isFire = false;

    void Awake()
    {
        _ballistics = GetComponent<Ballistics>();
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (gameObject.transform.position.y < -6)
            Destroy(gameObject, 2);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Ship"))
        {
            print("Take ship");
            _ship = collider.GetComponent<ShipController>();
            _ship.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    public void StartBallistics()
    {
        gameObject.SetActive(true);
        _ballistics.StartBallistics(gameObject);
    }

    public void RandTimeToStartBallistics(float firstTimeValue, float secondTimeValue)
    {
        gameObject.SetActive(true);
        StartCoroutine(StartRandBallistics(firstTimeValue, secondTimeValue));
    }
    public void IncreaseDamageAccountCannon(float cannonPower)
    {
        _damage *= cannonPower;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private IEnumerator StartRandBallistics(float firstTimeValue, float secondTimeValue)
    {
        float randomValueTime = Random.Range(firstTimeValue, secondTimeValue);

        yield return new WaitForSeconds(randomValueTime);
        StartBallistics();
    }
}