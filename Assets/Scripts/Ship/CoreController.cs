using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class CoreController : MonoBehaviour
{
    [SerializeField] private float _damage = 1f;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _angle = 45f;
    [SerializeField] private float _gravity = 9.8f;
    [SerializeField] private Ballistics _ballistics;
    private float _time;
    private ShipController _ship;
    private bool _isFire = false;
    void Awake()
    {
        _angle = _angle * Mathf.Deg2Rad;
    }

    void FixedUpdate()
    {
        if(gameObject.transform.position.y < 0)
            Destroy();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Ship")
        {
            _ship = collider.GetComponent<ShipController>();
            _ship.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    public void Fire()
    {
        print("start balistics");
        _ballistics.StartBallistics();
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
