using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private float _rateOfTurn = 1.0f;
    [SerializeField] private float _health = 100f;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Camera _aimLeftCamera;
    [SerializeField] private Camera _aimRightCamera;

    private Rigidbody _rigidbody;
    private Vector3 _moveDirection = Vector3.zero;
    private ShipController _ship;
    private CannonController[] _cannons;
    private bool _rightFire = true;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _ship = GetComponent<ShipController>();
        _aimLeftCamera.gameObject.SetActive(false);
        _aimRightCamera.gameObject.SetActive(false);
    }

    void Start()
    {
        _cannons = GetComponentsInChildren<CannonController>();
    }

    void Update()
    {
        Aim();
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

    private void Aim()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _rightFire = false;
            _mainCamera.gameObject.SetActive(false);
            _aimRightCamera.gameObject.SetActive(true);
            _aimLeftCamera.gameObject.SetActive(false);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            _rightFire = true;

            _mainCamera.gameObject.SetActive(false);
            _aimRightCamera.gameObject.SetActive(false);
            _aimLeftCamera.gameObject.SetActive(true);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            _mainCamera.gameObject.SetActive(true);
            _aimRightCamera.gameObject.SetActive(false);
            _aimLeftCamera.gameObject.SetActive(false);

            Fire(_rightFire);
        }

        if (Input.GetButtonUp("Fire2"))
        {
            _mainCamera.gameObject.SetActive(true);
            _aimRightCamera.gameObject.SetActive(false);
            _aimLeftCamera.gameObject.SetActive(false);

            Fire(_rightFire);
        }
    }
    private void MovementLogic()
    {
        _rigidbody.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * _moveSpeed * Time.fixedDeltaTime);

        _rigidbody.AddTorque(new Vector3(0.0f, Input.GetAxis("Horizontal"), 0.0f) * _rateOfTurn * Time.fixedDeltaTime);
    }

    private void Fire(bool rightFire)
    {
        if (rightFire)
        {
            foreach (var cannon in _cannons)
            {
                if(cannon.IsRightCannon())
                    cannon.Fire();
            }
        }

        if (!rightFire)
        {
            foreach (var cannon in _cannons)
            {
                if (!cannon.IsRightCannon())
                    cannon.Fire();
            }
        }
    }
}
