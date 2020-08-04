using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.0f;
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
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        _rigidbody.MoveRotation(Quaternion.RotateTowards(_rigidbody.rotation,, 10.0f * Time.fixedDeltaTime));
        
        _rigidbody.AddForce(movement * _moveSpeed * Time.fixedDeltaTime);
    }
}
