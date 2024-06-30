using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidVelocity : MonoBehaviour
{
    private Rigidbody _rb;
    public float _enemySpeed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _enemySpeed = SpawnAsteroids._boostSpeed;
    }
    private void FixedUpdate()
    {
        _rb.velocity = -transform.forward * _enemySpeed;

        if(transform.position.z < -2)
        {
            Destroy(gameObject);
        }
    }
}
