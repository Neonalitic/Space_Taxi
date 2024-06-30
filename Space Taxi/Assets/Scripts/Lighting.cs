using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Lighting : MonoBehaviour
{
    private Outline _lastObj;

    public TMP_Text _ore;
    float _oreCount;

    [SerializeField] private GameObject _oreHint;
    [SerializeField] private GameObject _baseHint;
    [SerializeField] private GameObject _fuelPanel;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _lastCam;
    [SerializeField] private GameObject _UI;

    [SerializeField] private TMP_Text _task1;

    [SerializeField] private AudioSource _pauseSound;
    public TMP_Text _fuelText;

    [SerializeField] private ParticleSystem _varp;
    [SerializeField] private AudioSource _varpSound;
    private void Start()
    {
        _ore.text = _oreCount.ToString();
        _varp.Stop();
     
        _oreHint.SetActive(false);
        _fuelPanel.SetActive(false);
        _baseHint.SetActive(false);
        _lastCam.SetActive(false);
    }
    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(_oreCount >= 7000)
        {
            _fuelText.color = Color.green;
            _task1.color = Color.green;
        }

        if (Physics.Raycast(ray, out hit, 100) == true)
        {
            if (hit.transform.gameObject.CompareTag("Stone"))
            {
                if (_lastObj != null)
                {
                    _lastObj.OutlineWidth = 0;
                    _oreHint.SetActive(false);
                }

                _lastObj = hit.transform.GetComponent<Outline>();
                _lastObj.OutlineWidth = 2;
                _oreHint.SetActive(true);

                if (Input.GetKey(KeyCode.E))
                {
                    _lastObj.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
                    _oreCount++;
                    _ore.text = _oreCount.ToString();
                    _oreHint.SetActive(false);
                }
            }
            else if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                if (_lastObj != null)
                {
                    _lastObj.OutlineWidth = 0;
                    _baseHint.SetActive(false);
                }

                _lastObj = hit.transform.GetComponent<Outline>();
                _lastObj.OutlineWidth = 2;
                _baseHint.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    Cursor.lockState = CursorLockMode.Confined;
                    Time.timeScale = 0;
                    _camera.GetComponent<CameraController>().enabled = false;
                    _fuelPanel.SetActive(true);
                    _baseHint.SetActive(false);
                    _pauseSound.Play();
                }

            }
            else if (hit.transform.gameObject.CompareTag("Portal"))
            {
                if (_lastObj != null)
                {
                    _lastObj.OutlineWidth = 0;
                    _baseHint.SetActive(false);
                }

                _lastObj = hit.transform.GetComponent<Outline>();
                _lastObj.OutlineWidth = 1;
                _baseHint.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    _lastCam.SetActive(true);
                    _camera.SetActive(false);
                    _UI.SetActive(false);
                    Invoke("Varp", 5f);
                    Invoke("ToNextScene", 7f);
                }
            }
            else if (_lastObj != null)
            {
                _lastObj.OutlineWidth = 0;
                _lastObj = null;
                _oreHint.SetActive(false);
            }
        }
    }

    private void Varp()
    {
        _varp.Play();
        _varpSound.PlayOneShot(_varpSound.clip);
    }
    private void ToNextScene()
    {
        SceneManager.LoadScene(2);
    }
}

