using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class CoreController : MonoBehaviour
{
    [SerializeField] private float _damage = 1f;
    private float _time;
    private ShipController _ship;
    private bool _isFire = false;

    void FixedUpdate()
    {
        //if(gameObject.transform.position.y < 0)
            //Destroy();
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

    public void IncreaseDamageAccountCannon(float cannonPower)
    {
        _damage *= cannonPower;
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
