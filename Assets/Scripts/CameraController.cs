using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _cameraSpeed = 4.0f;
    [SerializeField] private LayerMask _maskObstacles;
    private Vector3 _position;
    private RaycastHit _raycastObstacles;
    void Start()
    {
        _position = _target.InverseTransformPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        var preRotation = _target.rotation;

        _target.rotation = Quaternion.Euler(0, preRotation.eulerAngles.y, 0);
        var currentPosition = _target.TransformPoint(_position);

        transform.position = Vector3.Lerp(transform.position, currentPosition, _cameraSpeed * Time.deltaTime);
        _target.rotation = preRotation;

        var _currentRotation = Quaternion.LookRotation(_target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, _currentRotation, _cameraSpeed * Time.deltaTime);

        if (Physics.Raycast(_target.position, transform.position - _target.position, out _raycastObstacles,
            Vector3.Distance(transform.position, _target.position), _maskObstacles))
        {
            transform.position = _raycastObstacles.point;
            transform.LookAt(_target);
        }
    }
}
