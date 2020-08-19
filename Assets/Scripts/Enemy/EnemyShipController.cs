using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : Enemy
{
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private float _rateOfTurn = 1.0f;
    [SerializeField] private float _health = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}
