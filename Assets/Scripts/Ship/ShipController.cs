using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private float _rateOfTurn = 1.0f;
    [SerializeField] private float _health = 100f;
    private Rigidbody _rigidbody;
    private Vector3 _moveDirection = Vector3.zero;
    private ShipController _ship;
    private CannonController[] _cannons;
    private bool _rightFire = true;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _ship = GetComponent<ShipController>();
    }

    void Start()
    {
        _cannons = GetComponentsInChildren<CannonController>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
            Fire();
    }
    void FixedUpdate()
    {
        MovementLogic();
    }

    public void TakeDamage(float damage)
    {
        if (_health > 0)
            _health -= damage;
    }

    private void MovementLogic()
    {
        _rigidbody.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * _moveSpeed * Time.fixedDeltaTime);

        _rigidbody.AddTorque(new Vector3(0.0f, Input.GetAxis("Horizontal"), 0.0f) * _rateOfTurn * Time.fixedDeltaTime);
    }

    private void Fire()
    {
        if (_rightFire)
        {
            foreach (var cannon in _cannons)
            {
                if(cannon.IsRightCannon())
                    cannon.Fire();
            }
        }

        if (!_rightFire)
        {
            foreach (var cannon in _cannons)
            {
                if (cannon.IsRightCannon())
                    cannon.Fire();
            }
        }
    }
}
