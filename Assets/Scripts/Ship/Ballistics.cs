using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Ballistics : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _angle = 45f;
    [SerializeField] private float _gravity = 9.8f;
    private GameObject _bullet;
    private float _time;
    private bool _start;
    private float vz;
    private float vy;
    void Start()
    {
        _angle = _angle * Mathf.Deg2Rad;
        if(_bullet != null)
            Debug.Log(_bullet.name);
    }
    void FixedUpdate()
    {
        if (_start && _bullet != null)
        {
            _time += Time.fixedDeltaTime;
            vz = _speed * _time * Mathf.Cos(_angle) * Time.fixedDeltaTime;
            vy = _speed * _time * Mathf.Sin(_angle) * Time.fixedDeltaTime -
                       _gravity * (_time * _time) / 2 * Time.fixedDeltaTime;
            _bullet.gameObject.transform.localPosition += new Vector3(0f, vy, vz);
        }
        else
        {
            vy = 0.0f;
            vz = 0.0f;
        }
    }

    public void SetBullet(GameObject bullet)
    {
        _bullet = bullet;
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