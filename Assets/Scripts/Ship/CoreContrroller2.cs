using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballistics : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _angle = 45f;
    [SerializeField] private float _gravity = 9.8f;
    private float _time;
    private bool _start;

    void Start()
    {
        _angle = _angle * Mathf.Deg2Rad;
    }
    void FixedUpdate()
    {
        if (_start && _bullet != null)
        {
            _time += Time.fixedDeltaTime;
            float vz = _speed * _time * Mathf.Cos(_angle) * Time.fixedDeltaTime;
            float vy = _speed * _time * Mathf.Sin(_angle) * Time.fixedDeltaTime -
                       _gravity * (_time * _time) / 2 * Time.deltaTime;
            _bullet.transform.position += new Vector3(0, vy, vz);
        }
    }

    public void StartBallistics()
    {
        _start = true;
    }
    public void StartBallistics(GameObject bullet)
    {
        _bullet = bullet;
        _start = true;
    }
}
