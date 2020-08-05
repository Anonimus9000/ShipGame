using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private float _rateOfTurn = 1.0f;
    private Rigidbody _rigidbody;
    private Vector3 _moveDirection = Vector3.zero;
    private ShipController _ship;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _ship = GetComponent<ShipController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        _rigidbody.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * _moveSpeed * Time.fixedDeltaTime);

        _rigidbody.AddTorque(new Vector3(0.0f, Input.GetAxis("Horizontal"), 0.0f) * _rateOfTurn * Time.fixedDeltaTime);
    }
}
