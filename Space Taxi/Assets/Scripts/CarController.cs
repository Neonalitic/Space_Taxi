using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CarController : MonoBehaviour
{
    Rigidbody rb;
    public float _speed, rot_speed, _brake;
    public Transform _target;
    public float _hor, _ver;

    [SerializeField]
    private ParticleSystem _nitroParticle;
    [SerializeField]
    private List<ParticleSystem> _lasers = new List<ParticleSystem>();
    [SerializeField]
    private AudioSource _nitro, _crash, _laser;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _nitroParticle.Stop();
    }
    private void Update()
    {
        _ver = Input.GetAxis("Vertical");
        _hor = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (_speed > 0)
            {
                _speed -= _brake * Time.deltaTime;
            }
            else
            {
                _speed = 0;
            }
        }
        else
        {
            _speed = 1;
        }

        if(Input.GetKey(KeyCode.E))
        {
            for(int i = 0; i < _lasers.Count; i++)
            {
                _lasers[i].Play();
            }
            _laser.PlayOneShot(_laser.clip);
        }
        else
        {
            for (int i = 0; i < _lasers.Count; i++)
            {
                _lasers[i].Stop();
            }
            _laser.Stop();
        }
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, _target.rotation, rot_speed * Time.fixedDeltaTime);

        if (_ver > 0)
        {
            rb.AddForce(transform.forward * _speed);
            _nitroParticle.Play();
            if (!_nitro.isPlaying)
            {
                _nitro.PlayOneShot(_nitro.clip);
            }

        }
        else if (_ver < 0)
        {
            rb.AddForce(-transform.forward * _speed);
            _nitroParticle.Stop();
            _nitro.Stop();
        }
        else
        {
            rb.AddForce(0, 0, 0);
            rb.velocity = Vector3.MoveTowards(rb.velocity, Vector3.zero, _brake * Time.fixedDeltaTime);
            _nitroParticle.Stop();
            _nitro.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Crash"))
        {
            _crash.PlayOneShot(_crash.clip);
        }
    }
}
