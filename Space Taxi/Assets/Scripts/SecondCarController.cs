using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCarController : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _restartPanel;
    [SerializeField] private AudioSource _nitroSound;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _restartPanel.SetActive(false);
    }


    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        _rb.velocity = movement * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            _restartPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            _nitroSound.Stop();
            Time.timeScale = 0;
        }
    }
}