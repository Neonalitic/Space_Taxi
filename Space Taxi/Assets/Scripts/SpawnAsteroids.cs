using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    [SerializeField] private GameObject[] _asteroids;
    [SerializeField] private float _spawnSpeed = 1f;
    public static float _boostSpeed = 5;

    private void Start()
    {
        InvokeRepeating("Spawn", 1f, _spawnSpeed);
    }

    private void Update()
    {
        _spawnSpeed -= Time.deltaTime;
        _boostSpeed += Time.deltaTime / 10;
    }

    private void Spawn()
    {
        int random = Random.Range(0, _asteroids.Length - 1);
        Vector3 randomPos = new Vector3(Random.Range(-4.1f, 4.1f), Random.Range(2.5F, 7.5f), transform.position.z);
        Quaternion randomRot = Quaternion.Euler(0, 0, Random.Range(0, 360));
        GameObject pref = Instantiate(_asteroids[random], randomPos, randomRot);
    }
}
